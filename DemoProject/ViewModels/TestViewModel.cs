using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();

        public TestViewModel()
        {
            Items.CollectionChanged += _items_CollectionChanged;
        }

        private void _items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine($"items collection changed {e.Action}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
