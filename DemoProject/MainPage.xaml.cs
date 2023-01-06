using DemoProject.ViewModels;
using System;
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

            var random = new Random();
            for (int i = 0; i < 1; i++)
            {
                _viewModel.Items.Add(new Item { Length = random.Next(100) });
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var item in _viewModel.Items)
            {
                item.Length += 10;
            }
        }
    }
}
