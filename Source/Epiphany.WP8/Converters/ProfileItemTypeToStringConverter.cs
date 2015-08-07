using Epiphany.View.Resources;
using Epiphany.ViewModel;
using System;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class ProfileItemTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is ProfileItemType))
                return value;

            ProfileItemType type = (ProfileItemType)value;
            switch (type)
            {
                case ProfileItemType.Friends:
                    return AppResources.ViewFriendsText;
                case ProfileItemType.Groups:
                    return AppResources.ViewGroupsText;
                case ProfileItemType.ViewInGoodreads:
                    return AppResources.ViewInGoodreadsText;
                case ProfileItemType.Age:
                    return AppResources.AgeText;
                case ProfileItemType.Gender:
                    return AppResources.GenderText;
                case ProfileItemType.Interests:
                    return AppResources.InterestsText;
                case ProfileItemType.JoinDate:
                    return AppResources.JoinDateText;
                case ProfileItemType.Location:
                    return AppResources.LocationText;
                case ProfileItemType.Username:
                    return AppResources.UsernameText;
                case ProfileItemType.FriendStatus:
                    return AppResources.FriendStatusText;
                case ProfileItemType.FavoriteBooks:
                    return AppResources.FavoriteBooksText;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
