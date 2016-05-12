using Epiphany.Logging;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
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
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += ShareData;

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

        private void SearchResultsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems == null)
            {
                return;
            }

            if (e.AddedItems.Count > 0)
            {
            }
        }

        private void ShowShareUI(object sender, RoutedEventArgs e)
        {
            Logger.LogDebug("Sender: " + sender.ToString());
            this.selectedMenuItem = sender as FrameworkElement;
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }

        private void ShareData(DataTransferManager sender, DataRequestedEventArgs args)
        {
            try
            {
                var request = args.Request;
                var deferral = request.GetDeferral();

                if (this.selectedMenuItem == null)
                {
                    request.FailWithDisplayText(Strings.AppStrings.SharingFailedMessage);
                    Logger.LogError("There is no sender, Cannot share...");
                    deferral.Complete();
                    return;
                }

                if (this.selectedMenuItem.DataContext == null)
                {
                    request.FailWithDisplayText(Strings.AppStrings.SharingFailedMessage);
                    Logger.LogError("No Datacontext on sender. Cannot share...");
                    deferral.Complete();
                    return;
                }

                Logger.LogDebug(this.selectedMenuItem.DataContext.GetType().ToString());

                var searchResultItem = this.selectedMenuItem.DataContext as SearchResultItemViewModel;
                if (searchResultItem == null)
                {
                    request.FailWithDisplayText(Strings.AppStrings.SharingFailedMessage);
                    Logger.LogError("DataContext is not of expected type. Cannot share...");
                    deferral.Complete();
                    return;
                }

                request.Data.Properties.Title = Strings.AppStrings.ShareBookTitle;
                request.Data.Properties.Description = searchResultItem.Author.Name;
                request.Data.SetText(searchResultItem.Book.Title);
                request.Data.SetWebLink(new Uri(@"http://www.goodreads.com/book/show/" + searchResultItem.Book.Id));
                deferral.Complete();

                this.selectedMenuItem = null;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
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
    }
}
