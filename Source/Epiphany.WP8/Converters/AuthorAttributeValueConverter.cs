using Epiphany.ViewModel;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class AuthorAttributeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is AuthorAttributeViewModel))
                return value;

            AuthorAttributeViewModel vm = (AuthorAttributeViewModel)value;
            string strValue = string.Empty;
            switch (vm.Type)
            {
                case AuthorAttribute.About:
                    StringBuilder builder = new StringBuilder();
                    builder.AppendWithoutTags(vm.Value);
                    strValue = builder.ToString().Trim();
                    break;
                case AuthorAttribute.Born:
                    DateTime dt = DateTime.Parse(vm.Value);
                    strValue = String.Format("{0:y}", dt);
                    break;
                default:
                    strValue = vm.Value;
                    break;
            }
            return strValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
