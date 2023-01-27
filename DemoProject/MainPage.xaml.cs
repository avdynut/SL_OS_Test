using DemoProject.ViewModels;
using System.Windows;
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

            var xaml = @"<Canvas xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
            <Canvas.Resources>
                <LinearGradientBrush x:Key=""MyBrush"">
                    <GradientStop Offset=""0"" Color=""#ffcccccc""/>
                    <GradientStop Offset=""1"" Color=""#ffffffcc""/>
                </LinearGradientBrush>
            </Canvas.Resources>
            <Rectangle Width=""100""
                       Height=""20""
                       Fill=""{StaticResource MyBrush}""/>
        </Canvas>";

            try
            {
                var content = (UIElement)XamlReader.Load(xaml);
                //var viewbox = new Viewbox { Content = content, Width = 1000, Height = 800 };
                Grid.SetRow(content, 1);
                LayoutRoot.Children.Add(content);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
