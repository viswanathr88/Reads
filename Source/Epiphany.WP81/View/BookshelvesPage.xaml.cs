using System;
using System.Linq;
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

        private void Shelf_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Frame.Navigate(typeof(BooksPage), e.AddedItems.First());
            }
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
    }
}
