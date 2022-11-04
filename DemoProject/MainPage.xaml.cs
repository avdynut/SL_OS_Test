using DemoProject.ViewModels;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        public TestViewModel TestViewModel { get; set; } = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
