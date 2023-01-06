using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TestViewModel : ViewModelBase
    {
        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public class Item : ViewModelBase
    {
        private double _length;
        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }
    }
}
