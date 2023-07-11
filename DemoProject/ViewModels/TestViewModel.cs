using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private object _currentAdmission;
        public object CurrentAdmission
        {
            get { return _currentAdmission; }
            set
            {
                _currentAdmission = value;
                OnPropertyChanged(nameof(CurrentAdmission));
            }
        }

        public TestViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
