using System;
using System.ComponentModel;
using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Epiphany.View.Controls;
using Epiphany.Strings;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : DataPage
    {
        private readonly DataContextWrapper<IHomeViewModel> Context;
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            Context = new DataContextWrapper<IHomeViewModel>(DataContext);
            RegisterPropertyChanged();
            Loaded += MainPage_Loaded;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnViewModelPropertyChanged(sender, e);

            if (e.PropertyName == nameof(IHomeViewModel.IsLoggedIn))
            {
                UpdatePivotHeaders();
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePivotHeaders();
        }

        private void UpdatePivotHeaders()
        {
            var tabHeader = eventsOrMoreTabHeader.Content as TabHeader;

            if (Context.ViewModel.IsLoggedIn)
            {
                tabHeader.HeaderText = AppStrings.TabHeaderMore;
                tabHeader.Glyph = "\uE179";
            }
            else
            {
                tabHeader.HeaderText = AppStrings.TabHeaderEvents;
                tabHeader.Glyph = "\uE1C4";
            }
        }

        private void Search_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage), string.Empty, new ContinuumNavigationTransitionInfo());
        }

        private void Scan_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScanPage));
        }

        private void Settings_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage), VoidType.Empty, new SlideNavigationTransitionInfo());
        }

        private void PickerFlyout_Confirmed(Windows.UI.Xaml.Controls.PickerFlyout sender, Windows.UI.Xaml.Controls.PickerConfirmedEventArgs args)
        {
            Context.ViewModel.Feed.FeedOptions.Save.Execute(null);
        }

        private void PickerFlyout_Closed(object sender, object e)
        {
            Context.ViewModel.Feed.FeedOptions.Cancel.Execute(null);
        }

        private void ViewAllBooks_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var user = Context.ViewModel.CurrentlyLoggedInUser;

            if (user == null)
            {
                Logger.LogError("User is not logged in!");
                return;
            }

            Frame.Navigate(typeof(BookshelvesPage), user);
        }

        private async void Review_Click(object sender, ItemClickEventArgs e)
        {
            var reviewItemVM = e.ClickedItem as IReviewItemViewModel;
            await App.Navigate(typeof(ReviewPage), new ReviewParameter() { ReviewModel = reviewItemVM.Item as ReviewModel }, new SlideNavigationTransitionInfo());
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = sender as Pivot;
            if (pivot.SelectedIndex == 0)
            {
                // Show feed refresh
                this.refreshFeedButton.Visibility = Visibility.Visible;
                this.refreshCommunityButton.Visibility = Visibility.Collapsed;
            }
            else if (pivot.SelectedIndex == 2)
            {
                // Show Community refresh
                this.refreshCommunityButton.Visibility = Visibility.Visible;
                this.refreshFeedButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.refreshCommunityButton.Visibility = Visibility.Collapsed;
                this.refreshFeedButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
