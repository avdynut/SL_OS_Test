using DemoProject.ViewModels;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            var xaml = @"        <Canvas xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" Width=""46"" Height=""74.000001"">
            <Path Stroke=""#ff000000""/>
        </Canvas>";

            try
            {
                var content = XamlReader.Load(xaml);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
