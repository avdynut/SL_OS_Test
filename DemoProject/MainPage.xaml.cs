using DemoProject.ViewModels;
using System.Diagnostics;
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
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var isChecked = (sender as CheckBox).IsChecked.Value;
            _viewModel.IncludeAllChildren = isChecked;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine($"NumberOfCalls {Item.NumberOfCalls}");
        }
    }
}
