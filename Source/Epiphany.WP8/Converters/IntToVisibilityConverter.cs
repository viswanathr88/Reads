using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int val = (int)value;
                if (val > 0)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            else
                return Visibility.Collapsed;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
