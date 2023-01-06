using System;
using System.Windows.Controls;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

#if OPENSILVER
            CustomLayout = true;
#endif
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var percent = new Random().Next(0, 100);
            testGrid.ColumnDefinitions[0].Width = new System.Windows.GridLength(percent, System.Windows.GridUnitType.Star);
            testGrid.ColumnDefinitions[1].Width = new System.Windows.GridLength(100 - percent, System.Windows.GridUnitType.Star);
        }
    }
}
