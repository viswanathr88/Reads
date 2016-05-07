using Epiphany.Model;
using Epiphany.ViewModel.Items;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Epiphany.View.Controls
{
    public class FeedItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FriendFeedItemDataTemplate
        {
            get;
            set;
        }

        public DataTemplate ReadStatusFeedItemDataTemplate
        {
            get;
            set;
        }

        public DataTemplate ReviewFeedItemDataTemplate
        {
            get;
            set;
        }

        public DataTemplate UserStatusFeedItemDataTemplate
        {
            get;
            set;
        }

        public DataTemplate FallbackDataTemplate
        {
            get;
            set;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            FeedItemViewModel feedItem = item as FeedItemViewModel;

            if (feedItem != null)
            {
                if (feedItem.Type == FeedItemType.Friend)
                    return FriendFeedItemDataTemplate;
                else if (feedItem.Type == FeedItemType.Comment)
                    return FallbackDataTemplate;
                else if (feedItem.Type == FeedItemType.ReadStatus)
                    return ReadStatusFeedItemDataTemplate;
                else if (feedItem.Type == FeedItemType.UserStatus)
                    return UserStatusFeedItemDataTemplate;
                else
                    return ReviewFeedItemDataTemplate;
            }

            return null;
        }
    }
}
