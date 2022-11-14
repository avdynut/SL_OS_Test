#if OPENSILVER
using CSHTML5.Internal;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
#else
using Virtuoso.Core.Framework;
#endif
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Virtuoso.Core.Controls
{
#if OPENSILVER
    public class vRichTextArea : HtmlPresenterEx
#else
    public class vRichTextArea : RichTextBox
#endif
    {
        public event EventHandler OnParagraphTextChanged;

        public string XamlError
        {
            get { return (string)GetValue(XamlErrorProperty); }
            set { SetValue(XamlErrorProperty, value); }
        }
        public static DependencyProperty XamlErrorProperty =
          DependencyProperty.Register("XamlError", typeof(string), typeof(vRichTextArea), null);

        public bool DisplayMessageBoxOnError
        {
            get { return (bool)GetValue(DisplayMessageBoxOnErrorProperty); }
            set { SetValue(DisplayMessageBoxOnErrorProperty, value); }
        }
        public static DependencyProperty DisplayMessageBoxOnErrorProperty =
          DependencyProperty.Register("DisplayMessageBoxOnError", typeof(bool), typeof(vRichTextArea), null);

        public string ErrorXamlMessage { get; internal set; }

        public vRichTextArea(bool _displayMessageBoxOnError)
        {
            DisplayMessageBoxOnError = _displayMessageBoxOnError;
            init();
        }

        public vRichTextArea()
        {
            init();
        }

        void init()
        {
#if OPENSILVER
            try { this.Style = (Style)System.Windows.Application.Current.Resources["CoreHtmlPresenterStyle"]; }
            catch { }
#else
            try { this.Style = (Style)System.Windows.Application.Current.Resources["CoreRichTextAreaStyle"]; }
            catch { }
            this.IsReadOnly = true;
#endif
            this.IsTabStop = false;
            this.ErrorXamlMessage = "<Section xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>vRichTextArea.Xaml parse error</Paragraph></Section>";
            this.IsHitTestVisible = false;
        }

        public static DependencyProperty ParagraphTextProperty =
          DependencyProperty.Register("ParagraphText", typeof(string), typeof(vRichTextArea),
          new PropertyMetadata((o, e) =>
          {
              ((vRichTextArea)o).SetXamlFromParagraphText();
          }));

        public string ParagraphText
        {
            get { return (string)GetValue(ParagraphTextProperty); }
            set { SetValue(ParagraphTextProperty, value); }
        }

        private void SetXamlFromParagraphText()
        {
            string paragraphText = ParagraphText;
            this.XamlError = string.Empty;
            try
            {
                //FYI - US 4131 - added xml:space="preserve"
#if OPENSILVER
                this.Html = this.ProcessHtml(paragraphText);
#else
                this.Xaml = "<Section xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph xml:space=\"preserve\">" + paragraphText + "</Paragraph></Section>";
                ScrollViewer sv = this.Descendents().OfType<ScrollViewer>().FirstOrDefault();
                if (sv != null)
                {
                    this.Selection.Select(this.ContentStart, this.ContentStart); // This line of code makes sure that the text is scrolled to the top...
                }
#endif
            }
            catch (Exception xamlParseError)
            {
                this.XamlError = xamlParseError.Message;
#if OPENSILVER
                this.Html = $"vRichTextArea.Xaml parse error {xamlParseError}";
#else
                this.Xaml = this.ErrorXamlMessage;
#endif
                if (DisplayMessageBoxOnError)
                    MessageBox.Show(String.Format("Error vRichTextArea.SetXamlFromParagraphText: Parsing Xaml: {0}.  Contact your system administrator.", paragraphText));
            }

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                if (OnParagraphTextChanged != null) OnParagraphTextChanged(this, EventArgs.Empty);
            });
        }
    }

#if OPENSILVER
    /// <summary>
    /// Implementation is taken from CSHTML5.Native.Html.Controls.HtmlPresenter.
    /// We need the control to be inherited from Control class to support such properties as Foreground, FontSize, HorizontalAlignment and so on.
    /// </summary>
    [ContentProperty("Html")]
    public class HtmlPresenterEx : Control
    {
        #region HtmlPresenter
        private object _jsDiv;
        private string _htmlContent;

        public override object CreateDomElement(object parentRef, out object domElementWhereToPlaceChildren)
        {
            _jsDiv = INTERNAL_HtmlDomManager.CreateDomElementAndAppendIt("div", parentRef, this);
            domElementWhereToPlaceChildren = _jsDiv;
            return _jsDiv;
        }

        protected override void INTERNAL_OnAttachedToVisualTree()
        {
            base.INTERNAL_OnAttachedToVisualTree();

            if (_htmlContent != null)
            {
                ApplyHtmlContent(_htmlContent);
            }
        }

        public string Html
        {
            get => _htmlContent;
            set
            {
                _htmlContent = value;
                if (this.IsLoaded)
                {
                    ApplyHtmlContent(_htmlContent);
                }
            }
        }

        void ApplyHtmlContent(string htmlContent)
        {
            OpenSilver.Interop.ExecuteJavaScriptAsync($"$0.innerHTML = $1; $0.style.overflow = 'hidden';", _jsDiv, htmlContent);
        }
        #endregion

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(HtmlPresenterEx), new PropertyMetadata(false));

        public TextWrapping TextWrapping { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }
        public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }

        private string GetHtmlStyleFromStyleDictionary(Dictionary<string, string> styles)
        {
            string htmlStyle = "";
            if (styles.Any()) htmlStyle = "style=";
            foreach (var item in styles)
            {
                htmlStyle = $"{htmlStyle}{item.Key}:{item.Value};";
            }
            return htmlStyle;
        }

        private IEnumerable<string> GetTagsList(string originalText)
        {
            var expression = "<(“[^”]*”|'[^’]*’|[^'”>])*>";
            var regex = new Regex(expression);
            var result = regex.Matches(originalText).Cast<Match>().Select(u => u.Value);
            return result;
        }

        public string ProcessHtml(string originalText)
        {
            if (string.IsNullOrWhiteSpace(originalText)) return "";
            var tagsList = GetTagsList(originalText);
            var plainText = new StringBuilder(originalText);

            foreach (var tag in tagsList)
            {
                var styles = ReadInlinePropertiesFromTag(tag);
                string htmlStyle = GetHtmlStyleFromStyleDictionary(styles);

                //notice how we are not closing any tag like <Bold, to handle the situation of inline styles in these tags
                if (tag.StartsWith("<Bold")) plainText.Replace(tag, $"<b {htmlStyle}>");
                if (tag.StartsWith("<Underline")) plainText.Replace(tag, $"<u {htmlStyle}>");
                if (tag.StartsWith("<Italic")) plainText.Replace(tag, $"<i {htmlStyle}>");
                if (tag.StartsWith("<Run")) plainText.Replace(tag, $"<span {htmlStyle}>");
            }

            //all closing tags here, for them simple string replacement will work
            plainText.Replace("</Bold>", $"</b>");
            plainText.Replace("</Underline>", "</u>");
            plainText.Replace("</Italic>", "</i>");
            plainText.Replace("</Run>", "</span>");
            plainText.Replace("<LineBreak/>", "<br/>");

            var result = plainText.ToString();
            return result;
        }

        private Dictionary<string, string> ReadInlinePropertiesFromTag(string tag)
        {
            const string expression = "(\\w+)=(\"[^<>\"]*\"|'[^<>']*'|\\w+)";
            var styles = new Dictionary<string, string>();
            var matches = Regex.Matches(tag, expression);

            foreach (var match in matches)
            {
                var values = match.ToString().Split('=');
                if (values.Count() == 2)
                {
                    var property = values.First();
                    if (property == nameof(Foreground))
                    {
                        var colorText = values.Last().ToString();
                        if (colorText.Length >= 2 && (colorText[0] == '\'' || colorText[0] == '"') && colorText[0] == colorText[colorText.Length - 1])
                        {
                            string colorName = colorText.Substring(1, colorText.Length - 2);
                            if (colorName.StartsWith("#"))
                                styles["color"] = HexToColor(colorName);
                            else
                                styles["color"] = colorName;
                        }
                        else
                            styles["color"] = colorText;
                    }
                    else if (property == nameof(FontSize))
                    {
                        string fontSize = values.Last().ToString();
                        if ((fontSize[0] == '\'' || fontSize[0] == '"') && fontSize[0] == fontSize[fontSize.Length - 1])
                        {
                            fontSize = fontSize.Substring(1, fontSize.Length - 2);
                        }
                        styles["font-size"] = fontSize + "px";
                    }
                    else if (property == nameof(FontFamily))
                    {
                        string fontFamily = values.Last().ToString();
                        if ((fontFamily[0] == '\'' || fontFamily[0] == '"') && fontFamily[0] == fontFamily[fontFamily.Length - 1])
                        {
                            fontFamily = fontFamily.Substring(1, fontFamily.Length - 2);
                        }
                        styles["font-family"] = fontFamily;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Property {property} is not supported");
                    }
                }
            }

            return styles;
        }

        public static string HexToColor(string hexColor)
        {
            if (string.IsNullOrWhiteSpace(hexColor))
                return "";

            if (hexColor.Length == 7) // opacity is not specified
            {
                return hexColor;
            }

            // converting from C# ARGB to JS RGBA color
            var jsColor = $"#{hexColor.Substring(3, 6)}{hexColor.Substring(1, 2)}";
            return jsColor;
        }
    }
#else
    //this is a dummy class to resolve the issue of missing type in silverlight version
    //missing type exception is raised from style for HTMLPresenterEx from CoreStyles.xaml
    public class HtmlPresenterEx : RichTextBox
    {
    }
#endif
}