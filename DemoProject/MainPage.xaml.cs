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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Text changed to {(sender as TextBox).Text}");
        }
    }
}
