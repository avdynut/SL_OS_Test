using DemoProject.ViewModels;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.CurrentAdmission = "1";
        }
    }
}
