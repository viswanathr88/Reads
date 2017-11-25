using Epiphany.Logging;
using Epiphany.ViewModel;
using Epiphany.WP81;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

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

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                var list = sender as ListView;
                switch (list.SelectedIndex)
                {
                    case 0:
                        {
                            var user = Context.ViewModel.CurrentlyLoggedInUser;

                            if (user == null)
                            {
                                Logger.LogError("User is not logged in!");
                            }
                            else
                            {
                                await App.Navigate(typeof(ProfilePage), user);
                            }

                            break;
                        }
                    case 1:
                        {
                            var user = Context.ViewModel.CurrentlyLoggedInUser;

                            if (user == null)
                            {
                                Logger.LogError("User is not logged in!");
                            }
                            else
                            {
                                await App.Navigate(typeof(FriendsPage), user);
                            }

                            break;
                        }
                    case 3:
                        {
                            await App.Navigate(typeof(EventsPage), VoidType.Empty);
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
