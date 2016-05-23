using Epiphany.Model.Services;
using Epiphany.Strings;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Epiphany.View.Converters
{
    public sealed class BooksOrderByTextConverter : DependencyObject, IValueConverter
    {
        public BookSortType SortType
        {
            get { return (BookSortType)GetValue(SortTypeProperty); }
            set { SetValue(SortTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SortType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SortTypeProperty =
            DependencyProperty.Register("SortType", typeof(BookSortType), typeof(BooksOrderByTextConverter), new PropertyMetadata(BookSortType.date_added));

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            BookSortOrder sortOrder = (BookSortOrder)value;
            BookSortType sortType = SortType;
            string result = string.Empty;

            switch (sortType)
            {
                case BookSortType.author:
                case BookSortType.title:
                case BookSortType.review:
                case BookSortType.cover:
                case BookSortType.owned:
                    {
                        result = (sortOrder == BookSortOrder.a) ? AppStrings.BooksSortOrderAscending : AppStrings.BooksSortOrderDescending;
                        break;
                    }

                case BookSortType.avg_rating:
                case BookSortType.num_pages:
                case BookSortType.num_ratings:
                case BookSortType.rating:
                case BookSortType.read_count:
                    result = (sortOrder == BookSortOrder.a) ? AppStrings.BooksSortOrderLowest : AppStrings.BooksSortOrderHighest;
                    break;

                case BookSortType.date_added:
                case BookSortType.date_read:
                case BookSortType.date_started:
                case BookSortType.year_pub:
                    result = (sortOrder == BookSortOrder.a) ? AppStrings.BooksSortOrderOldest : AppStrings.BooksSortOrderNewest;
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
