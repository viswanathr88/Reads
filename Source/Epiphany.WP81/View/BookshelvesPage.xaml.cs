using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BookshelvesPage : DataPage
    {
        public BookshelvesPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Add_Clicked(object sender, RoutedEventArgs e)
        {
            await addShelfDialog.ShowAsync();
        }

        private void Home_Clicked(object sender, RoutedEventArgs e)
        {
            while (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void Shelf_Clicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var shelfItemVM = e.ClickedItem as IBookshelfItemViewModel;
                await App.Navigate(typeof(BooksPage), shelfItemVM);
            }
        }
    }
}
