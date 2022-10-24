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
            AllDisciplines = new List<Discipline>
            {
                new Discipline { Description = "All", DisciplineKey = -99 },
                new Discipline { Description = "Aide", DisciplineKey = 1 },
                new Discipline { Description = "Bereavement", DisciplineKey = 2 },
                new Discipline { Description = "Case Management", DisciplineKey = 3 },
                new Discipline { Description = "Errand Assistance", DisciplineKey = 4 },
                new Discipline { Description = "Facility Service", DisciplineKey = 5 },
                new Discipline { Description = "Home Health Aide", DisciplineKey = 6 },
                new Discipline { Description = "Home Support - Light Housekeeping and Laundry", DisciplineKey = 7 },
                new Discipline { Description = "HomeMaker", DisciplineKey = 8 },
                new Discipline { Description = "Hospice Aide", DisciplineKey = 9 },
                new Discipline { Description = "Hospice Occupational Therapy", DisciplineKey = 10 },
                new Discipline { Description = "Hospice Physical Therapy", DisciplineKey = 11 },
                new Discipline { Description = "Hospice Physician Services", DisciplineKey = 12 },
                new Discipline { Description = "Hospice Room and Board", DisciplineKey = 13 },
                new Discipline { Description = "Hospice Skilled Nursing ", DisciplineKey = 14 },
                new Discipline { Description = "Hospice Social Worker", DisciplineKey = 15 },
                new Discipline { Description = "Hospice Speech Language Pathology/ Speech Therapy", DisciplineKey = 16 },
                new Discipline { Description = "Hospice Volunteer", DisciplineKey = 17 },
                new Discipline { Description = "Licensed Nurse LHCSA", DisciplineKey = 18 },
                new Discipline { Description = "Maternal Antepartum", DisciplineKey = 19 },
                new Discipline { Description = "Maternal Newborn", DisciplineKey = 20 },
                new Discipline { Description = "Medical Social Work", DisciplineKey = 21 },
                new Discipline { Description = "Music Therapy", DisciplineKey = 22 },
                new Discipline { Description = "Occupational Therapy", DisciplineKey = 23 },
                new Discipline { Description = "Pediatric Nursing", DisciplineKey = 24 },
                new Discipline { Description = "Personal Care Aide", DisciplineKey = 25 },
                new Discipline { Description = "Physical Therapy", DisciplineKey = 26 },
                new Discipline { Description = "Physician", DisciplineKey = 27 },
                new Discipline { Description = "Registered Dietician", DisciplineKey = 28 },
                new Discipline { Description = "Skilled Nurse Home Care", DisciplineKey = 29 },
                new Discipline { Description = "Skilled Nursing", DisciplineKey = 30 },
                new Discipline { Description = "Speech Language Pathology/ Speech Therapy", DisciplineKey = 31 },
                new Discipline { Description = "Spiritual Counseling", DisciplineKey = 32 },
                new Discipline { Description = "Supply Drop", DisciplineKey = 33 },
                new Discipline { Description = "Telehealth", DisciplineKey = 34 },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
