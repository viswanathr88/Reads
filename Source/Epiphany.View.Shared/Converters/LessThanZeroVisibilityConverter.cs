using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public sealed class LessThanZeroVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value is int)
            {
                int number = (int)value;
                visibility = number < 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
