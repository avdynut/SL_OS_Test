using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DemoProject
{
    public partial class ChildWindow1 : ChildWindow
    {
        public ChildWindow1()
        {
            InitializeComponent();
#if OPENSILVER
            (Content as FrameworkElement).CustomLayout = true;
#endif
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            //scrollViewer.InvalidateMeasure();
            //scrollViewer.InvalidateArrange();
            //scrollViewer.UpdateLayout();
            //scrollViewer.InvalidateScrollInfo();
            scrollViewer.ScrollToVerticalOffset(1);
            //scrollViewer.ScrollToTop();
            //this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }

}