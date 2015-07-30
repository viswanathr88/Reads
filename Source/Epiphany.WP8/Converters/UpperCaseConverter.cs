using System;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class UpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = (string)value;
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            else
            {
                return text.ToUpper();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
