using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _number = 1;
        public int Number => _number++;

        public Item Item { get; } = new Item();

        private int _number2 = 1;
        public UIElement Control => new TextBlock { Text = _number2++.ToString() };

        public void RaiseChanged()
        {
            RaiseChanged(nameof(Number));
            RaiseChanged(nameof(Item));
            RaiseChanged(nameof(Control));
        }

        private void RaiseChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item
    {
        private int _number = 1;
        public string Value => _number++.ToString();
    }
}
