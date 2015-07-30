using System;
using System.Windows;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            bool val = (bool)value;
            if (val)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            Visibility visibility = (Visibility)value;
            if (visibility == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
