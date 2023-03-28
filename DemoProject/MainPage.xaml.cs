using DemoProject.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            Debug.WriteLine($"Initialized, {GetFocusedElement()}");
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"OnLostFocus {sender}, {GetFocusedElement()}");
        }

        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"OnGotFocus {sender}, {GetFocusedElement()}");
        }

        private string GetFocusedElement()
        {
            var focusedElement = FocusManager.GetFocusedElement();
            textBlock.Text = "Focused Element: " + focusedElement;
            return textBlock.Text;
        }
    }
}
