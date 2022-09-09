using DemoProject.ViewModels;
using System.Diagnostics;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly Test _viewModel = new Test();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine($"RadioButton {sender} {e.OriginalSource}");
        }
    }
}
