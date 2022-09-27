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
            Debug.WriteLine($"NumberOfCalls {Item.NumberOfCalls}");
            Item.NumberOfCalls = 0;
            var isChecked = (sender as CheckBox).IsChecked.Value;

            for (int i = 0; i < 10000; i++)
            {
                _viewModel.IncludeAllChildren = isChecked;
            }

            Debug.WriteLine($"NumberOfCalls {Item.NumberOfCalls}");
        }
    }
}
