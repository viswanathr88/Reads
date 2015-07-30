using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class DateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime val = (DateTime)value;
                if (val == default(DateTime))
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
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
