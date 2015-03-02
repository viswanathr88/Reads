using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility result = Visibility.Collapsed;
            if (value is bool)
            {
                bool val = (bool)value;
                result = val ? Visibility.Visible : Visibility.Collapsed;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool result = false;

            Visibility val = (Visibility)value;
            if (val == Visibility.Visible)
            {
                result = true;
            }
            return result;
        }
    }
}
