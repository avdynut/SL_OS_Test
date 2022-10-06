using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public List<Item> AllServiceLineList { get; } = new List<Item>();

        public List<Item> ServiceLineList
        {
            get
            {
                if (IncludeAllChildren)
                {
                    return AllServiceLineList;
                }
                return AllServiceLineList.Where(x => x.Number % 2 == 0).ToList();
            }
        }

        private bool _IncludeAllChildren;
        public bool IncludeAllChildren
        {
            get { return _IncludeAllChildren; }
            set
            {
                _IncludeAllChildren = value;

                AllServiceLineList.ForEach(SetupIncludeAllChildren);

                RaisePropertyChanged("IncludeAllChildren");
                RaisePropertyChanged("ServiceLineList");
            }
        }

        public TestViewModel()
        {
            CreateItems();
            Item.NumberOfCalls = 0;
        }

        private void CreateItems()
        {
            for (int i = 0; i < 2; i++)
            {
                var item = new Item { Number = i, Id = $"{i}" };
                AllServiceLineList.Add(item);

                for (int j = 0; j < 2; j++)
                {
                    var childItem = new Item { Number = j, Id = $"{i}{j}" };
                    item.AllChildItems.Add(childItem);

                    for (int k = 0; k < 2; k++)
                    {
                        var subItem = new Item { Number = k, Id = $"{i}{j}{k}" };
                        childItem.AllChildItems.Add(subItem);

                        for (int l = 0; l < 2; l++)
                        {
                            var subItem2 = new Item { Number = l, Id = $"{i}{j}{k}{l}" };
                            subItem.AllChildItems.Add(subItem2);

                            //for (int m = 0; m < 2; m++)
                            //{
                            //    var subItem3 = new Item { Number = m, Id = $"{i}{j}{k}{l}{m}" };
                            //    subItem2.AllChildItems.Add(subItem3);

                            //    for (int n = 0; n < 2; n++)
                            //    {
                            //        var subItem4 = new Item { Number = n, Id = $"{i}{j}{k}{l}{m}{n}" };
                            //        subItem3.AllChildItems.Add(subItem4);
                            //    }
                            //}
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
            sl.AllChildItems?.ForEach(slg => slg.IncludeAllChildren = IncludeAllChildren);

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

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public static int NumberOfCalls;

        public List<Item> AllChildItems { get; } = new List<Item>();

        public List<Item> ChildItems
        {
            get
            {
                NumberOfCalls++;
                //Debug.WriteLine($"get_ChildItems {new StackTrace()}");

                if (IncludeAllChildren)
                {
                    return AllChildItems;
                }
                return AllChildItems.Where(x => x.Number % 2 == 0).ToList();
            }
        }

        public int Number { get; set; }
        public string Id { get; set; }

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
