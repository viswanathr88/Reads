using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class DoubleToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                double val = (double)value;
                if (val > 0.0)
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
