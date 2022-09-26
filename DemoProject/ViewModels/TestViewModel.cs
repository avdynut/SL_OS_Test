using System.Collections.Generic;
using System.ComponentModel;
using Virtuoso.Core.Controls;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public List<Discipline> AllDisciplines { get; set; }

        private string _SelectedDisciplines = "-99|";
        public string SelectedDisciplines
        {
            get { return _SelectedDisciplines; }
            set
            {
                _SelectedDisciplines = value;

                //RaisePropertyChanged("SelectedDisciplines");

                //AsyncUtility.Run(() => base.RefreshCollectionViews().ContinueWith(_ =>
                //{
                //    Deployment.Current.Dispatcher.BeginInvoke(() => RaisePropertyChanged("CurrentCount"));
                //}));
            }
        }

        public TestViewModel()
        {
            AllDisciplines = new List<Discipline>();

            for (int i = 0; i < 100000; i++)
            {
                AllDisciplines.Add(new Discipline { DisciplineKey = i, Description = i.ToString() });
            }

            AllDisciplines.Insert(0, new Discipline { Description = "All", DisciplineKey = -99 });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
