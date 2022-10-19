using DemoProject.ViewModels;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();
        private readonly Signature _entry = new Signature();
        private readonly Equipment _equipment = new Equipment();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.PopupDataContext = _entry;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.PopupDataContext = _equipment;
        }
    }
}
