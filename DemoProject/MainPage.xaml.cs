using DemoProject.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        public TestViewModel TestViewModel { get; set; } = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var datatemplate = Resources["UserDataTemplate"] as DataTemplate;
            var content = datatemplate.LoadContent();
            contentControl.Content = content;
            DataContext = this;
        }
    }
}
