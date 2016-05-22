using Epiphany.Logging;
using Epiphany.ViewModel;
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
        public MainPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void Search_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchPage), string.Empty, new ContinuumNavigationTransitionInfo());
        }

        private void Scan_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScanPage));
        }

        private void PickerFlyout_Confirmed(Windows.UI.Xaml.Controls.PickerFlyout sender, Windows.UI.Xaml.Controls.PickerConfirmedEventArgs args)
        {
            GetViewModel<HomeViewModel>().Feed.FeedOptions.Save.Execute(null);
        }

        private void PickerFlyout_Closed(object sender, object e)
        {
            GetViewModel<HomeViewModel>().Feed.FeedOptions.Cancel.Execute(null);
        }

        private void ViewAllBooks_Clicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var user = GetViewModel<HomeViewModel>().CurrentlyLoggedInUser;

            if (user == null)
            {
                Logger.LogError("User is not logged in!");
                return;
            }

            Frame.Navigate(typeof(BookshelvesPage), user);
        }
    }
}
