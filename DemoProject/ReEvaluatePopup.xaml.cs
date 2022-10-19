using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class ReEvaluatePopup : UserControl
    {
        public ReEvaluatePopup()
        {
            InitializeComponent();
            DataContextChanged += ReEvaluatePopup_DataContextChanged;
        }

        private void ReEvaluatePopup_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine($"ReEvaluatePopup_DataContextChanged to {e.NewValue ?? "null"} from {e.OldValue ?? "null"}");
        }
    }
}