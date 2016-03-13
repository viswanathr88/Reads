using Epiphany.Strings;
using Epiphany.ViewModel;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public sealed class AuthorAttributeTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AuthorAttribute)) return value;

            AuthorAttribute type = (AuthorAttribute)value;
            string strType = string.Empty;
            switch (type)
            {
                case AuthorAttribute.About:
                    strType = AppResources.AuthorAboutTitle;
                    break;
                case AuthorAttribute.NumberOfFans:
                    strType = AppResources.AuthorNumberOfFans;
                    break;
                case AuthorAttribute.NumberOfWorks:
                    strType = AppResources.AuthorNumberOfWorks;
                    break;
                case AuthorAttribute.AverageRating:
                    strType = AppResources.AuthorAverageRating;
                    break;
                case AuthorAttribute.Born:
                    strType = AppResources.AuthorBorn;
                    break;
                case AuthorAttribute.Gender:
                    strType = AppResources.AuthorGender;
                    break;
                case AuthorAttribute.Hometown:
                    strType = AppResources.AuthorHometown;
                    break;
                case AuthorAttribute.Influences:
                    strType = AppResources.AuthorInfluences;
                    break;
            }
            return strType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
