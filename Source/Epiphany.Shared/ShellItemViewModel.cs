using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel
{
    public enum ShellItemType
    {
        Feed,
        MyProfile,
        MyBooks,
        Friends,
        Events,
        Groups
    };

    public sealed class ShellItemViewModel : ViewModelBase
    {
        private readonly ShellItemType type;

        private const string FeedShellItemKey = "FeedShellItemText";
        private const string MyProfileShellItemKey = "MyProfileShellItemText";
        private const string MyBooksShellItemKey = "MyBooksShellItemText";
        private const string FriendsShellItemKey = "FriendsShellItemText";
        private const string EventsShellItemKey = "EventsShellItemText";
        private const string GroupsShellItemKey = "GroupsShellItemText";

        public ShellItemViewModel(ShellItemType type)
        {
            this.type = type;
        }

        public string Text
        {
            get
            {
                return GetText(type);
            }
        }

        public void Navigate(INavigationService navigationService, Session session)
        {
            switch (type)
            {
                case ShellItemType.Feed:
                    navigationService.Navigate<FeedViewModel, VoidType>(VoidType.Empty);
                    break;
                case ShellItemType.MyProfile:
                    navigationService.Navigate<ProfileViewModel, int>(int.Parse(session.UserId));
                    break;
            }
        }

        private string GetText(ShellItemType type)
        {
            string text = string.Empty;
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            switch (type)
            {
                case ShellItemType.Feed:
                    text = loader.GetString(FeedShellItemKey);
                    break;
                case ShellItemType.MyProfile:
                    text = loader.GetString(MyProfileShellItemKey);
                    break;
                case ShellItemType.MyBooks:
                    text = loader.GetString(MyBooksShellItemKey);
                    break;
                case ShellItemType.Friends:
                    text = loader.GetString(FriendsShellItemKey);
                    break;
                case ShellItemType.Events:
                    text = loader.GetString(EventsShellItemKey);
                    break;
                case ShellItemType.Groups:
                    text = loader.GetString(GroupsShellItemKey);
                    break;
            }

            return text;
        }
    }
}
