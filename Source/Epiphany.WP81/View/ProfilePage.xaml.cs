using Epiphany.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

        private void Friends_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FriendsPage), GetViewModel<IProfileViewModel>().Parameter, new Windows.UI.Xaml.Media.Animation.SlideNavigationTransitionInfo());
        }

        private void Shelves_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BookshelvesPage), GetViewModel<IProfileViewModel>().Parameter, new Windows.UI.Xaml.Media.Animation.SlideNavigationTransitionInfo());
        }
    }
}
