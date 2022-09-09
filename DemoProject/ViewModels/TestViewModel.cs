using System.Collections.Generic;
using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Test
    {
        public List<TestViewModel> Items { get; set; } = new List<TestViewModel>
        {
            new TestViewModel { Name = "option 1" },
            new TestViewModel { Name = "option 2" },
            new TestViewModel { Name = "option 3" },
        };
    }
}
