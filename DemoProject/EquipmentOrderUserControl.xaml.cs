using DemoProject.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class EquipmentOrderUserControl : UserControl
    {
        private SignatureOrderEntry _vm;

        public EquipmentOrderUserControl()
        {
            InitializeComponent();

            DataContextChanged += (s, e) => _vm = e.NewValue as SignatureOrderEntry;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.ParentViewModel.PopupDataContext = this;
        }

        private object _popupDataTemplateLoaded;
        public object PopupDataTemplateLoaded
        {
            get
            {
                if (_popupDataTemplateLoaded == null)
                {
                    _popupDataTemplateLoaded = new AdmissionEquipmentPopup();
                }
                return _popupDataTemplateLoaded;
            }
        }

        public void Cancel()
        {
            _vm.ParentViewModel.PopupDataContext = null;
        }
    }
}