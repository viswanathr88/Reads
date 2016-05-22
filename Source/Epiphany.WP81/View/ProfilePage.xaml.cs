using Epiphany.ViewModel;
using Epiphany.WP81;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : DataPage
    {
        public ProfilePage()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Friends_Click(object sender, RoutedEventArgs e)
        {
            var parameter = GetViewModel<IProfileViewModel>().Parameter;
            await App.Navigate(typeof(FriendsPage), parameter, new SlideNavigationTransitionInfo());
        }

        private async void Shelves_Click(object sender, RoutedEventArgs e)
        {
            var parameter = GetViewModel<IProfileViewModel>().Parameter;
            await App.Navigate(typeof(BookshelvesPage), parameter, new SlideNavigationTransitionInfo());
        }
    }
}
