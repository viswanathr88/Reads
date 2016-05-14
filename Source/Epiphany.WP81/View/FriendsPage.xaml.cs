using Epiphany.Model;
using Epiphany.ViewModel;
using System.Linq;
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
        }

        private void OnUserSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var userItem = e.AddedItems.First() as ItemViewModel<UserModel>;
                Frame.Navigate(typeof(ProfilePage), userItem.Item);
            }
        }
    }
}
