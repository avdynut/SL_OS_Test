using System.ComponentModel;
using System.Diagnostics;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private object _currentMode;
        public object CurrentMode
        {
            get { return _currentMode; }
            set
            {
                Debug.WriteLine($"CurrentMode changed to {value ?? "null"}");
                _currentMode = value;
                OnPropertyChanged(nameof(CurrentMode));
            }
        }

        public TestViewModel()
        {
            CurrentMode = "1";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
