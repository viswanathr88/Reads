using System;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public class ValueParameterComparerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool fSame = false;

            if (value.GetType() == parameter.GetType())
            {
                fSame = value.Equals(parameter);
            }

            return fSame;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
