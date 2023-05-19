using System.ComponentModel;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = @"DescriptionescriptionD


























escriptionDescriptionDescriptionDescriptionDescription";

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
