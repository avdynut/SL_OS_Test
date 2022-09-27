using System.Collections.Generic;
using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public List<Item> Items { get; } = new List<Item>();

        private bool _IncludeAllChildren;
        public bool IncludeAllChildren
        {
            get { return _IncludeAllChildren; }
            set
            {
                _IncludeAllChildren = value;

                Items.ForEach(SetupIncludeAllChildren);

                RaisePropertyChanged("IncludeAllChildren");
                RaisePropertyChanged("Items");
            }
        }

        public TestViewModel()
        {
            CreateItems();
        }

        private void CreateItems()
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

        private void SetupIncludeAllChildren(Item sl)
        {
            //sl.IsExpanded = false;
            //sl.ServiceLineGrouping?.ForEach(slg => slg.IsExpanded = false);

            sl.IncludeAllChildren = IncludeAllChildren;
            sl.ChildItems?.ForEach(slg => slg.IncludeAllChildren = IncludeAllChildren);

            if (IncludeAllChildren)
            {
                //sl.IsExpanded = sl.SomeChildHasSelections;
                //sl.ServiceLineGrouping?.ForEach(slg => slg.IsExpanded = slg.SomeChildHasSelections);
            }
            else
            {
                //sl.IsExpanded = true;
                //sl.ServiceLineGrouping?.ForEach(slg => slg.IsExpanded = true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public static int NumberOfCalls;

        private readonly List<Item> _childItems = new List<Item>();
        public List<Item> ChildItems
        {
            get
            {
                NumberOfCalls++;
                return _childItems;
            }
        }

        public int Number { get; set; }

        private bool _IncludeAllChildren;
        public bool IncludeAllChildren
        {
            get { return _IncludeAllChildren; }
            set
            {
                _IncludeAllChildren = value;
                RaisePropertyChanged("IncludeAllChildren");
                RaisePropertyChanged("ChildItems");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
