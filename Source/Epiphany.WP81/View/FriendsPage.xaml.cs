using Epiphany.ViewModel.Items;
using Epiphany.WP81;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Epiphany.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendsPage : DataPage
    {
        public FriendsPage()
        {
            this.InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Required;
        }

        private async void Friend_Clicked(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                var userItemVM = e.ClickedItem as IUserItemViewModel;
                await App.Navigate(typeof(ProfilePage), userItemVM.Item);
            }
        }
    }
}
