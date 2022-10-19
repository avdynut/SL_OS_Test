using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class AdmissionEquipmentPopup : UserControl
    {
        public AdmissionEquipmentPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as EquipmentOrderUserControl;
            vm.Cancel();
        }
    }
}