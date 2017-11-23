using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : DataPage
    {
        public BooksPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void ScrollToTop(object sender, RoutedEventArgs e)
        {
            if (this.booksList.Items.Count > 0)
            {
                this.booksList.ScrollIntoView(this.booksList.Items[0]);
            }
        }

        private async void Book_Click(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var parameter = (e.ClickedItem as BookItemViewModel).Item;
                await App.Navigate(typeof(BookPage), parameter);
            }
        }

        private void Home_Clicked(object sender, RoutedEventArgs e)
        {
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
