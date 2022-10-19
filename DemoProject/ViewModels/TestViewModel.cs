using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private object _PopupDataContext;
        public object PopupDataContext
        {
            get { return _PopupDataContext; }
            set
            {
                _PopupDataContext = value;
                OnPropertyChanged(nameof(PopupDataContext));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Signature
    {
        public object PopupDataTemplateLoaded { get; }

        public Signature()
        {
            var control = new TextBlock { Text = "Signature" };
            control.DataContextChanged += OnDataContextChanged;
            PopupDataTemplateLoaded = control;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Signature DataContextChanged to {e.NewValue ?? "null"} from {e.OldValue ?? "null"}");
        }
    }

    public class Equipment
    {
        public object PopupDataTemplateLoaded { get; }

        public Equipment()
        {
            var control = new TextBlock { Text = "Equipment" };
            control.DataContextChanged += OnDataContextChanged;
            PopupDataTemplateLoaded = control;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"Equipment DataContextChanged to {e.NewValue ?? "null"} from {e.OldValue ?? "null"}");
        }
    }
}
