using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace DemoProject.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        List<object> PopupDataContextStack = new List<object>();

        private object _PopupDataContext;
        public object PopupDataContext
        {
            get { return _PopupDataContext; }
            set
            {
                if (value == null)
                {
                    if (PopupDataContextStack.Any())
                    {
                        _PopupDataContext = PopupDataContextStack.Last();
                        PopupDataContextStack.Remove(_PopupDataContext);
                    }
                    else
                    {
                        _PopupDataContext = null;
                    }

                    OnPropertyChanged(nameof(PopupDataContext));
                }
                else
                {
                    if (PopupDataContextStack.Any() && (PopupDataContextStack.Contains(value)))
                    {
                        PopupDataContextStack.Remove(value); // backing up a level
                    }
                    else
                    {
                        if (_PopupDataContext != null)
                        {
                            PopupDataContextStack.Add(_PopupDataContext); // going down a level
                        }
                    }

                    _PopupDataContext = value;
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        OnPropertyChanged(nameof(PopupDataContext));
                    });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SignatureOrderEntry
    {
        private object _popupDataTemplateLoaded;
        public object PopupDataTemplateLoaded
        {
            get
            {
                if (_popupDataTemplateLoaded == null)
                {
                    _popupDataTemplateLoaded = new ReEvaluatePopup();
                }
                return _popupDataTemplateLoaded;
            }
        }

        public TestViewModel ParentViewModel { get; set; }

        public SignatureOrderEntry(TestViewModel parentVM)
        {
            ParentViewModel = parentVM;
        }
    }
}
