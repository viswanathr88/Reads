using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Services;
using Windows.UI.Xaml.Controls;

namespace Epiphany.ViewModel
{
    public enum ShellItemType
    {
        Feed,
        MyProfile,
        MyBooks,
        Friends,
        Events,
        Groups,
        Settings
    };

    public sealed class ShellItemViewModel : ViewModelBase
    {
        private readonly ShellItemType type;

        private string text;
        private Symbol icon;

        private const string FeedShellItemKey = "FeedShellItemText";
        private const string MyProfileShellItemKey = "MyProfileShellItemText";
        private const string MyBooksShellItemKey = "MyBooksShellItemText";
        private const string FriendsShellItemKey = "FriendsShellItemText";
        private const string EventsShellItemKey = "EventsShellItemText";
        private const string GroupsShellItemKey = "GroupsShellItemText";
        private const string SettingsShellItemKey = "SettingsShellItemText";

        public ShellItemViewModel(ShellItemType type)
        {
            this.type = type;
            GetTextAndIcon(type);
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            private set
            {
                if (this.text == value) return;
                this.text = value;
                RaisePropertyChanged();
            }
        }

        public Symbol Icon
        {
            get
            {
                return this.icon;
            }
            private set
            {
                if (this.icon == value) return;
                this.icon = value;
                RaisePropertyChanged();
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

        private void GetTextAndIcon(ShellItemType type)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            switch (type)
            {
                case ShellItemType.Feed:
                    Text = loader.GetString(FeedShellItemKey);
                    Icon = Symbol.PreviewLink;
                    break;
                case ShellItemType.MyProfile:
                    Text = loader.GetString(MyProfileShellItemKey);
                    Icon = Symbol.ContactInfo;
                    break;
                case ShellItemType.MyBooks:
                    Text = loader.GetString(MyBooksShellItemKey);
                    Icon = Symbol.Library;
                    break;
                case ShellItemType.Friends:
                    Text = loader.GetString(FriendsShellItemKey);
                    Icon = Symbol.People;
                    break;
                case ShellItemType.Events:
                    Text = loader.GetString(EventsShellItemKey);
                    Icon = Symbol.Map;
                    break;
                case ShellItemType.Groups:
                    Text = loader.GetString(GroupsShellItemKey);
                    Icon = Symbol.ViewAll;
                    break;
                case ShellItemType.Settings:
                    Text = loader.GetString(SettingsShellItemKey);
                    Icon = Symbol.Setting;
                    break;
            }
        }
    }
}
