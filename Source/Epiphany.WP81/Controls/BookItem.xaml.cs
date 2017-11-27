using Epiphany.Model;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class BookItem : UserControl
    {
        public BookItem()
        {
            this.InitializeComponent();
        }

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageUrl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageUrlProperty =
            DependencyProperty.Register("ImageUrl", typeof(string), typeof(BookItem), new PropertyMetadata(string.Empty));


        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(BookItem), new PropertyMetadata(string.Empty));


        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Author.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AuthorProperty =
            DependencyProperty.Register("Author", typeof(string), typeof(BookItem), new PropertyMetadata(string.Empty));


        public int RatingsCount
        {
            get { return (int)GetValue(RatingsCountProperty); }
            set { SetValue(RatingsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RatingsCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingsCountProperty =
            DependencyProperty.Register("RatingsCount", typeof(int), typeof(BookItem), new PropertyMetadata(0));

        public double AverageRating
        {
            get { return (double)GetValue(AverageRatingProperty); }
            set { SetValue(AverageRatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AverageRating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AverageRatingProperty =
            DependencyProperty.Register("AverageRating", typeof(double), typeof(BookItem), new PropertyMetadata(0));


        public string ExtraInfo
        {
            get { return (string)GetValue(ExtraInfoProperty); }
            set { SetValue(ExtraInfoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExtraInfo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtraInfoProperty =
            DependencyProperty.Register("ExtraInfo", typeof(string), typeof(BookItem), new PropertyMetadata(string.Empty));

        public Visibility ExtraInfoVisibility
        {
            get { return (Visibility)GetValue(ExtraInfoVisibilityProperty); }
            set { SetValue(ExtraInfoVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExtraInfoVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExtraInfoVisibilityProperty =
            DependencyProperty.Register("ExtraInfoVisibility", typeof(Visibility), typeof(BookItem), new PropertyMetadata(Visibility.Collapsed));

        private async void Book_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement.DataContext is IReviewItemViewModel)
            {
                var reviewItemVM = frameworkElement.DataContext as IReviewItemViewModel;
                if (reviewItemVM.Book != null)
                {
                    await App.Navigate(typeof(BookPage), reviewItemVM.Book.Item);
                }
            }
            else if (frameworkElement.DataContext is ISearchResultItemViewModel)
            {
                var searchResultItemVM = frameworkElement.DataContext as ISearchResultItemViewModel;
                if (searchResultItemVM.Book != null)
                {
                    await App.Navigate(typeof(BookPage), searchResultItemVM.Book.Item);
                }
            }
            else if (frameworkElement.DataContext is IBookItemViewModel)
            {
                var bookItemVM = frameworkElement.DataContext as IBookItemViewModel;
                if (bookItemVM != null)
                {
                    await App.Navigate(typeof(BookPage), bookItemVM.Item);
                }
            }
            
        }

        private async void Author_Click(object sender, RoutedEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement.DataContext is IReviewItemViewModel)
            {
                var reviewItemVM = frameworkElement.DataContext as IReviewItemViewModel;
                if (reviewItemVM.Book != null)
                {
                    await App.Navigate(typeof(AuthorPage), reviewItemVM.Book.MainAuthor.Item);
                }
            }
            else if (frameworkElement.DataContext is ISearchResultItemViewModel)
            {
                var searchResultItemVM = frameworkElement.DataContext as ISearchResultItemViewModel;
                if (searchResultItemVM.Book != null)
                {
                    await App.Navigate(typeof(AuthorPage), searchResultItemVM.Book.MainAuthor.Item);
                }
            }
            else if (frameworkElement.DataContext is IBookItemViewModel)
            {
                var bookItemVM = frameworkElement.DataContext as IBookItemViewModel;
                if (bookItemVM != null)
                {
                    await App.Navigate(typeof(AuthorPage), bookItemVM.MainAuthor.Item);
                }
            }
        }
    }
}
