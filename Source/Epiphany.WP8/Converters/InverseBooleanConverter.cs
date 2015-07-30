using System;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return false;
            bool val = (bool)value;
            return !val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return false;
            bool val = (bool)value;
            return !val;
        }
    }
}
