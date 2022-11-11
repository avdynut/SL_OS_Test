using DemoProject.ViewModels;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            try
            {
                var paragraphText = "В Хоббитоне был<LineBreak/> переполох...";
                //richText.Xaml = "<Section xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph xml:space=\"preserve\">" + paragraphText + "</Paragraph></Section>";

                // Create a Run of plain text and some bold text.
                //Run myRun1 = new Run() { FontSize = 20 };
                //myRun1.Text = "A RichTextBox with ";
                //Bold myBold = new Bold();
                //myBold.Inlines.Add("initial content ");
                //Run myRun2 = new Run();
                //myRun2.Text = "in it.";

                //// Create a paragraph and add the Run and Bold to it.
                //Paragraph myParagraph = new Paragraph();
                //myParagraph.Inlines.Add(myRun1);
                //myParagraph.Inlines.Add(new LineBreak());
                //myParagraph.Inlines.Add(myBold);
                //myParagraph.Inlines.Add(myRun2);

                //// Add the paragraph to the RichTextBox.
                //richText.Blocks.Add(myParagraph);
                var d = richText.Xaml;
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
