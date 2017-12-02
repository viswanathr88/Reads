using Epiphany.Logging;
using Epiphany.View.Share;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : DataPage
    {
        FrameworkElement selectedMenuItem = null;

        public SearchPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private async void SearchInput_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                var searchVM = DataContext as SearchViewModel;
                if (searchVM != null)
                {
                    // Dismiss keyboard
                    this.Focus(FocusState.Programmatic);

                    await searchVM.LoadAsync(searchVM.SearchTerm);
                }
            }
        }

        private void SearchResult_Holding(object sender, HoldingRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element == null)
            {
                Logger.LogError("Sender is not framework element");
                return;
            }

            var flyout = FlyoutBase.GetAttachedFlyout(element);
            if (flyout == null)
            {
                Logger.LogError("No flyout found on item");
                return;
            }

            flyout.ShowAt(element);
        }

        private void ShowShareUI(object sender, RoutedEventArgs e)
        {
            Logger.LogDebug("Sender: " + sender.ToString());
            this.selectedMenuItem = sender as FrameworkElement;
            var itemVM = this.selectedMenuItem.DataContext as ISearchResultItemViewModel;

            var bookShare = new BookShare();
            bookShare.Share(itemVM.Book.Item);

            this.selectedMenuItem = null;
        }

        private void ScrollToTop(object sender, RoutedEventArgs e)
        {
            if (this.searchResultsList == null)
            {
                Logger.LogDebug("Search results is null");
                return;
            }

            if (this.searchResultsList.Items.Count > 0)
            {
                this.searchResultsList.ScrollIntoView(this.searchResultsList.Items[0]);
            }
        }

        private async void Book_Click(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var searchItemVM = e.ClickedItem as ISearchResultItemViewModel;
                if (searchItemVM == null)
                {
                    Logger.LogError("Item is not of type ISearchResultItemViewModel");
                    return;
                }

                await App.Navigate(typeof(BookPage), searchItemVM.Book.Item);
            }
        }
    }
}
