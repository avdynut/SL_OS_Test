using DemoProject.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();
        private readonly ChildWindow1 _window = new ChildWindow1();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            SizeChanged += MainPage_SizeChanged;
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _window.Width = e.NewSize.Width - 100;
            _window.Height = e.NewSize.Height - 100;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _window.Show();
        }
    }
}
