using System;
using System.Windows;
using Virtuoso.Core.View;
//using Virtuoso.Maintenance.ViewModel;

namespace Virtuoso.Maintenance.Views
{
    public partial class PatientList : PageBaseTab
    {
        public PatientList()
        {
            InitializeComponent();
            //Export = Virtuoso.Client.Core.VirtuosoContainer.Current.GetExport<PatientViewModel>();
            //this.DataContext = Export.Value;

            this.Loaded += new RoutedEventHandler(PatientList_Loaded);
        }

        private object formContentObject = null;
        private object popupContentObject = null;
        private bool firstLoad = true;

        void PatientList_Loaded(object sender, RoutedEventArgs e)
        {
            if (firstLoad)
            {
                object wellContentObject = wellContent.Content;
                formContentObject = formContent.Content;
                formContent.Content = null;
                popupContentObject = popupContent.Content;
                popupContent.Content = null;
                wellContent.Content = formContentObject;
                firstLoad = false;
            }
        }

        private void IsPopupVisible_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                wellContent.Style =
                    (Style)System.Windows.Application.Current.Resources[
                        "CoreTransitioningContentControlStyleRightToLeft"];
            }
            catch
            {
            }

            wellContent.UpdateLayout();
            wellContent.Content = popupContentObject;
        }

        private void IsPopupVisible_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                wellContent.Style =
                    (Style)System.Windows.Application.Current.Resources[
                        "CoreTransitioningContentControlStyleLeftToRight"];
            }
            catch
            {
            }

            wellContent.UpdateLayout();
            wellContent.Content = formContentObject;
        }

        public override bool Cleanup()
        {
            this.Loaded -= PatientList_Loaded;
            isPopupVisible.Checked -= IsPopupVisible_Checked;
            isPopupVisible.Unchecked -= IsPopupVisible_Unchecked;
            formContent.Content = null;
            popupContent.Content = null;
            wellContent.Content = null;

            return base.Cleanup();
        }
    }
}