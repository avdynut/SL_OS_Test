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

            for (int i = 0; i < 30; i++)
            {
                panel.Children.Add(new Button { Content = "Button " + i });
            }

            alignmentCombobox.Items.Add(VerticalAlignment.Stretch);
            alignmentCombobox.Items.Add(VerticalAlignment.Top);
            alignmentCombobox.Items.Add(VerticalAlignment.Center);
            alignmentCombobox.Items.Add(VerticalAlignment.Bottom);
            alignmentCombobox.SelectedIndex = 0;
        }
    }
}
