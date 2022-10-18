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
            var d = treeView.Parent as TabItem;
            d.Content = null;
            var isChecked = (sender as CheckBox).IsChecked.Value;
            _viewModel.IncludeAllChildren = isChecked;
            d.Content = treeView;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine($"NumberOfCalls {Item.NumberOfCalls}");
            (sender as Button).Content = $"NumberOfCalls {Item.NumberOfCalls}";
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.RaisePropertyChanged("ServiceLineList");
        }
    }
}
