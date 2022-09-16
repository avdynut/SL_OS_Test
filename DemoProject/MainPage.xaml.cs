using DemoProject.ViewModels;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly Test _viewModel = new Test();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;
            (itemsControl.Items as INotifyCollectionChanged).CollectionChanged += Items_CollectionChanged;
        }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine($"RadioButton {sender} {e.OriginalSource}");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Text changed to {(sender as TextBox).Text}");
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine($"Items count changed to {itemsControl.Items.Count}");
        }

        private void contentButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine($"Content control {contentControl.Content}");
        }
    }
}
