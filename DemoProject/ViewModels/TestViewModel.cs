using System.Collections.Generic;
using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public List<Item> Items { get; } = new List<Item>();

        public TestViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                var item = new Item { Number = i };
                Items.Add(item);

                for (int j = 0; j < 3; j++)
                {
                    var childItem = new Item { Number = j };
                    item.ChildItems.Add(childItem);

                    for (int k = 0; k < 2; k++)
                    {
                        var subItem = new Item { Number = k };
                        childItem.ChildItems.Add(subItem);
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item
    {
        public List<Item> ChildItems { get; } = new List<Item>();
        public int Number { get; set; }
    }
}
