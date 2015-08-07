using Epiphany.WP8;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Epiphany.View.Converters
{
    public class EnabledToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            
            if (val)
            {
                return (SolidColorBrush)App.Current.Resources["PhoneAccentBrush"];
            }
            else
            {
                return (SolidColorBrush)App.Current.Resources["PhoneSubtleBrush"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
