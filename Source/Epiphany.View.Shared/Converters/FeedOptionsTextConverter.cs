using Epiphany.Model.Services;
using Epiphany.Strings;
using System;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public class FeedOptionsTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string result = string.Empty;

            if (value is FeedUpdateType)
            {
                switch ((FeedUpdateType)value)
                {
                    case FeedUpdateType.all:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesForAllText;
                            break;
                        }
                    case FeedUpdateType.books:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesForBooksText;
                            break;
                        }
                    case FeedUpdateType.reviews:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesForReviewsText;
                            break;
                        }
                    case FeedUpdateType.statuses:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesForStatusesText;
                            break;
                        }
                }
            }
            else if (value is FeedUpdateFilter)
            {
                switch ((FeedUpdateFilter)value)
                {
                    case FeedUpdateFilter.friends:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesFromFriendsText;
                            break;
                        }
                    case FeedUpdateFilter.following:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesFromFollowersText;
                            break;
                        }
                    case FeedUpdateFilter.top_friends:
                        {
                            result = AppStrings.FeedOptionsShowUpdatesFromTopFriendsText;
                            break;
                        }
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
