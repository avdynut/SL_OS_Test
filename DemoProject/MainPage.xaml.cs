using DemoProject.ViewModels;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        private int _radius = 2;

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            textElement.Effect = new BlurEffect { Radius = _radius };
            _radius += 2;
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            textElement.Effect = new DropShadowEffect { BlurRadius = _radius };
            _radius += 2;
        }

        private void Button_Click_2(object sender, System.Windows.RoutedEventArgs e)
        {
            textElement.Effect = null;
        }
    }
}
