using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    /// <summary>
    /// Represents a boolean to visibility converter
    /// </summary>
    public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert from boolean to visibility. True == Visible, False == Collapsed
        /// </summary>
        /// <param name="value">boolean to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Collapsed;

            if (value != null && value is bool)
            {
                visibility = (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            return visibility;
        }
        /// <summary>
        /// Convert from visibility to boolean. Visible == True, Collapsed == False
        /// </summary>
        /// <param name="value">Visibility</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool fValue = false;

            if (value != null && value is Visibility)
            {
                Visibility visibility = (Visibility)value;
                fValue = (visibility == Visibility.Visible);
            }

            return fValue;
        }
    }
}
