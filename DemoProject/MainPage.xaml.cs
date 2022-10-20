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
                //panel.Children.Add(new Button { Content = "Button " + i });
                listBox.Items.Add(new Button { Content = "Button " + i });
            }

            verticalAlignmentCombobox.Items.Add(VerticalAlignment.Stretch);
            verticalAlignmentCombobox.Items.Add(VerticalAlignment.Top);
            verticalAlignmentCombobox.Items.Add(VerticalAlignment.Center);
            verticalAlignmentCombobox.Items.Add(VerticalAlignment.Bottom);
            verticalAlignmentCombobox.SelectedIndex = 0;

            horizontalAlignmentCombobox.Items.Add(HorizontalAlignment.Stretch);
            horizontalAlignmentCombobox.Items.Add(HorizontalAlignment.Left);
            horizontalAlignmentCombobox.Items.Add(HorizontalAlignment.Center);
            horizontalAlignmentCombobox.Items.Add(HorizontalAlignment.Right);
            horizontalAlignmentCombobox.SelectedIndex = 0;
        }
    }
}
