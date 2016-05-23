using Epiphany.Model.Services;
using Epiphany.Strings;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public sealed class BooksFilterTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BookSortType sortType = (BookSortType)value;

            string result = string.Empty;
            switch (sortType)
            {
                case BookSortType.author:
                    result = AppStrings.BooksFilterAuthor;
                    break;
                case BookSortType.avg_rating:
                    result = AppStrings.BooksFilterAverageRating;
                    break;
                case BookSortType.cover:
                    result = AppStrings.BooksFilterCover;
                    break;
                case BookSortType.date_added:
                    result = AppStrings.BooksFilterDateAdded;
                    break;
                case BookSortType.date_read:
                    result = AppStrings.BooksFilterDateRead;
                    break;
                case BookSortType.date_started:
                    result = AppStrings.BooksFilterDateStarted;
                    break;
                case BookSortType.num_pages:
                    result = AppStrings.BooksFilterNumPages;
                    break;
                case BookSortType.num_ratings:
                    result = AppStrings.BooksFilterNumRatings;
                    break;
                case BookSortType.owned:
                    result = AppStrings.BooksFilterOwned;
                    break;
                case BookSortType.rating:
                    result = AppStrings.BooksFilterRating;
                    break;
                case BookSortType.read_count:
                    result = AppStrings.BooksFilterReadCount;
                    break;
                case BookSortType.review:
                    result = AppStrings.BooksFilterReview;
                    break;
                case BookSortType.title:
                    result = AppStrings.BooksFilterTitle;
                    break;
                case BookSortType.year_pub:
                    result = AppStrings.BooksFilterYearPublished;
                    break;
                default:
                    result = string.Empty;
                    break;

            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
