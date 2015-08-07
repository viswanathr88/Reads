using Epiphany.View.Resources;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Windows.Data;

namespace Epiphany.View.Converters
{
    public class ProfileItemValueToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is ProfileItemViewModel))
                return value;

            ProfileItemViewModel vm = value as ProfileItemViewModel;
            ProfileItemType type = vm.Type;
            string strValue = vm.Value;
            switch (type)
            {
                case ProfileItemType.Friends:
                    string text = string.Empty;
                    int numberOfFriends = 0;
                    if (int.TryParse(strValue, out numberOfFriends))
                    {
                        if (numberOfFriends == 1)
                            text = string.Format("{0} {1}", numberOfFriends, AppResources.NumberedItemFriendSingular);
                        else
                            text = string.Format("{0} {1}", numberOfFriends, AppResources.NumberedItemFriendPlural);
                    }
                    return text;
                case ProfileItemType.Groups:
                    text = string.Empty;
                    int numberOfGroups = 0;
                    if (int.TryParse(strValue, out numberOfGroups))
                    {
                        if (numberOfGroups == 1)
                            text = string.Format("{0} {1}", numberOfGroups, AppResources.NumberedItemGroupSingular);
                        else
                            text = string.Format("{0} {1}", numberOfGroups, AppResources.NumberedItemGroupPlural);
                    }
                    return text;
                case ProfileItemType.FriendStatus:
                    if (strValue == "RequestPending")
                        return AppResources.PendingApprovalText;
                    else
                        return strValue;
                case ProfileItemType.JoinDate:
                    DateTime time = DateTime.Parse(strValue);
                    strValue = String.Format("{0:y}", time);
                    return strValue;
                default:
                    return strValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
