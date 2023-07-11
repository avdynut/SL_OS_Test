using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class AdmissionDiagnosisUserControl : UserControl
    {
        public object Admission
        {
            get { return (object)GetValue(AdmissionProperty); }
            set { SetValue(AdmissionProperty, value); }
        }

        public static readonly DependencyProperty AdmissionProperty =
            DependencyProperty.Register("Admission", typeof(object), typeof(AdmissionDiagnosisUserControl), new PropertyMetadata(AdmissionPropertyChanged));

        private static void AdmissionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("AdmissionPropertyChanged");
        }

        public AdmissionDiagnosisUserControl()
        {
            InitializeComponent();
            DataContextChanged += AdmissionDiagnosisUserControl_DataContextChanged;
        }

        private void AdmissionDiagnosisUserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("AdmissionDiagnosisUserControl_DataContextChanged");
        }
    }
}
