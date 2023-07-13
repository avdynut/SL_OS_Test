using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DemoProject
{
    public class TestConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            Debug.WriteLine($"Convert {value ?? "null"}");
            if (value == null)
            {
                return Visibility.Collapsed;
            }

            if (value.ToString().Trim() == "")
            {
                return Visibility.Collapsed;
            }

            if (value.ToString().Trim() == "Both")
            {
                return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            Debug.WriteLine($"ConvertBack {value}");
            return null;
        }
    }
}