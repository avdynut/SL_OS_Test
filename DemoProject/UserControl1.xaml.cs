using DemoProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DemoProject
{
    public partial class UserControl1 : UserControl, INotifyPropertyChanged
    {
        public TestViewModel TestViewModel
        {
            get { return (TestViewModel)GetValue(TestViewModelProperty); }
            set { SetValue(TestViewModelProperty, value); }
        }

        public static readonly DependencyProperty TestViewModelProperty =
            DependencyProperty.Register("TestViewModel", typeof(TestViewModel), typeof(UserControl1),
            new PropertyMetadata(TestViewModelPropertyChanged)); //Callback invoked on property value has changes

        private static void TestViewModelPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            try
            {
                var instance = sender as UserControl1;
                instance.ProcessFilteredItems();
                //instance.RaisePropertyChanged("IsTestViewModel");
                //instance.RaiseTestViewModelChangedEvent();
                //try
                //{
                //    instance.RaiseCanExecuteChanged();
                //}
                //catch (Exception e)
                //{
                //    MessageBox.Show(String.Format("DEBUG: {0}", e.Message));
                //    throw;
                //}
            }
            catch (Exception oe)
            {
                MessageBox.Show(String.Format("DEBUG: {0}", oe.Message));
                throw;
            }
        }

        public ICollection<Item> ItemsSource
        {
            get
            {
                return (ICollection<Item>)GetValue(ItemsSourceProperty);
            }
            set
            {
                if (ItemsSource != null)
                {
                    try
                    {
                        ((INotifyCollectionChanged)ItemsSource).CollectionChanged -=
                            new NotifyCollectionChangedEventHandler(UserControlBase_CollectionChanged);
                    }
                    catch { }
                }
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(ICollection<Item>), typeof(UserControl1),
                new PropertyMetadata(ItemsSourcePropertyChanged)); //Callback invoked on property value has changes

        private static void ItemsSourcePropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            //((ISelectedItem<E>)(sender)).SelectedItem = ((ICollection<Item>)(((C)(sender))
            //    .GetValue(ItemSourceProperty))).FirstOrDefault();

            try
            {
                var control = (UserControl1)sender;
                var itemsSource = (ICollection<Item>)control.GetValue(ItemsSourceProperty);
                control.ProcessFilteredItems();
                control.RaisePropertyChanged("ItemsSource");
                try
                {
                    if ((itemsSource != null) && (control.SelectedItem != null))
                    {
                        control.SelectedItem = null;
                        //control.RaiseItemSelected(EventArgs.Empty);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(String.Format("DEBUG: {0}", e.Message));
                    throw;
                }

                control.ProcessFilteredItems();
                control.RaisePropertyChanged("ItemsSource");
                if (itemsSource != null)
                {
                    //register changes to the collection - not changes to properties in the collection...
                    ((INotifyCollectionChanged)control.ItemsSource).CollectionChanged +=
                        new NotifyCollectionChangedEventHandler(control.UserControlBase_CollectionChanged);
                }
                //control.AutoEdit();
            }
            catch (Exception oe)
            {
                MessageBox.Show(String.Format("DEBUG: {0}", oe.Message));
                throw;
            }

        }

        public void UserControlBase_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ProcessFilteredItems();
        }

        public void ProcessFilteredItems()
        {
            //OnPreProcessFilteredItems();

            //FilteredCount = 0;

            //oggleDisplayText = ToggleFilteredItems ? "Current" : "All";
            //this.RaisePropertyChanged("ToggleDisplayText");

            if (ItemsSource != null)
            {
                //FilteredItemsSource = new PagedCollectionView(ItemsSource);
                _FilteredItemsSource.Source = ItemsSource;

                FilteredItemsSource.SortDescriptions.Clear();
                //if (!string.IsNullOrEmpty(SortOrder))
                //{
                //    string[] sorts = SortOrder.Split('|');
                //    for (int i = 0; i < sorts.Length; i++)
                //    {
                //        if (sorts[i].StartsWith("-"))
                //            FilteredItemsSource.SortDescriptions.Add(new SortDescription(sorts[i].Substring(1), ListSortDirection.Descending));
                //        else
                //            FilteredItemsSource.SortDescriptions.Add(new SortDescription(sorts[i], ListSortDirection.Ascending));
                //    }
                //}

                FilteredItemsSource.Refresh();
                //FilteredItemsSource.Filter = new Predicate<object>(FilterItems);
                if (SelectedItem == null)
                {
                    FilteredItemsSource.MoveCurrentToFirst();
                    SelectedItem = (Item)FilteredItemsSource.CurrentItem;
                }
                this.RaisePropertyChanged("FilteredItemsSource");

                //this.PrintFilteredItemsSource = FilteredItemsSource;

            }

            //AnyItemsCheck = (FilteredItemsSource == null || FilteredCount == 0);

            //if (FilteredItemsSourceChanged != null)
            //{
            //    var e = new UserControlBaseEventArgs<E>(null);
            //    FilteredItemsSourceChanged(this, e);
            //}
            //OnProcessFilteredItems();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CollectionViewSource _FilteredItemsSource = new CollectionViewSource();
        public ICollectionView FilteredItemsSource
        {
            get { return _FilteredItemsSource.View; }
        }

        private Item _SelectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
                //return (E)GetValue(SelectedItemProperty);
            }
            set
            {
                if (_SelectedItem != null)
                {
                    try
                    {
                        SelectedItem.PropertyChanged -= SelectedItem_PropertyChanged;
                    }
                    catch { }
                }

                _SelectedItem = value;

                if (SelectedItem != null)
                    SelectedItem.PropertyChanged += SelectedItem_PropertyChanged;
                //RaiseCanExecuteChanged();

                //RaiseItemSelected(EventArgs.Empty); - this was causing a nested re-call to this setter with a null causing the add to 're-point' to the first item in the list
                RaisePropertyChanged("SelectedItem");
                //RaiseItemSelected(EventArgs.Empty);
            }
        }

        public void SelectedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //RaiseCanExecuteChanged();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine($"DataGrid_SelectionChanged {e.AddedItems?.Count}");
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = new Item { Name = DateTime.Now.ToString(), Number = (int)DateTime.Now.Ticks };
            ItemsSource.Add(item);
            ProcessFilteredItems();

            SelectedItem = item;
        }
    }
}