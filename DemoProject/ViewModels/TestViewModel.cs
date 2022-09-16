using System.Collections.Generic;
using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public List<Item> Items { get; } = new List<Item>();

        public TestViewModel()
        {
            for (int i = 0; i < 7; i++)
            {
                var item = new Item { Number = i };
                Items.Add(item);

                for (int j = 0; j < 2; j++)
                {
                    var childItem = new Item { Number = j };
                    item.ChildItems.Add(childItem);

                    for (int k = 0; k < 1; k++)
                    {
                        var subItem = new Item { Number = k };
                        childItem.ChildItems.Add(subItem);

                        for (int l = 0; l < 1; l++)
                        {
                            var subItem2 = new Item { Number = l };
                            subItem.ChildItems.Add(subItem2);

                            for (int m = 0; m < 2; m++)
                            {
                                var subItem3 = new Item { Number = m };
                                subItem2.ChildItems.Add(subItem3);

                                for (int n = 0; n < 1; n++)
                                {
                                    var subItem4 = new Item { Number = n };
                                    subItem3.ChildItems.Add(subItem4);
                                }
                            }
                        }
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
