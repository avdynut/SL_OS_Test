using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Data;

namespace DemoProject.ViewModels
{
    public class TestViewModel
    {
        public CollectionViewSource TestCollection { get; }

        public TestViewModel()
        {
            TestCollection = new CollectionViewSource();
            TestCollection.SortDescriptions.Add(new SortDescription("Number", ListSortDirection.Ascending));
        }

        public void LoadCollection()
        {
            var random = new Random();
            var max = 10;

            var list = new List<Item>
            {
                new Item{ Name = "a", Number = random.Next(max) },
                new Item{ Name = "b", Number = random.Next(max) },
                new Item{ Name = "c", Number = random.Next(max) },
            };

            TestCollection.Source = list;
        }
    }

    public class Item
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
