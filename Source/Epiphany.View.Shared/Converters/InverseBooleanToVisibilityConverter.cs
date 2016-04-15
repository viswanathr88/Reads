using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    /// <summary>
    /// Represents an inverse boolean to visibility converter
    /// </summary>
    public sealed class InverseBooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// False == Visible, True == Collapsed
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Visible;

            if (value != null && value is bool)
            {
                if ((bool)value == true)
                {
                    visibility = Visibility.Collapsed;
                }
            }

            return visibility;
        }
        /// <summary>
        /// Visible == False, Collapsed == true
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            bool fValue = true;

            if (value != null && value is Visibility)
            {
                Visibility visibility = (Visibility)value;
                fValue = (visibility != Visibility.Visible);
            }

            return fValue;
        }
    }
}
