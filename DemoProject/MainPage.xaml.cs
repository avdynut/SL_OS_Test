using DemoProject.ViewModels;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly MainViewModel _viewModel = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            BindingValidationError += MainPage_BindingValidationError;
        }

        private void MainPage_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.Test.Validate();
        }
    }
}
