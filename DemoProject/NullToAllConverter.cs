using System;
using System.Globalization;
using System.Windows.Data;

namespace DemoProject
{
    public class NullToAllConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            if (strValue == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(strValue.Trim()))
            {
                return "All";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
