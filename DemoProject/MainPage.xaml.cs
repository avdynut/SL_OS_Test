using DemoProject.ViewModels;
using System.Windows;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count;
            int.TryParse(countText.Text, out count);

            datagrid.ItemsSource = null;
            _viewModel.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                _viewModel.Items.Add(new Item { Number = i, Name = "Name ", Description = "descr" });
            }
            //_viewModel.OnPropertyChanged("Items");

            datagrid.ItemsSource = _viewModel.Items;
        }
    }
}
