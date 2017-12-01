using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Epiphany.Model;
using Epiphany.WP81;
using Epiphany.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class LauncherControl : UserControl
    {
        public LauncherControl()
        {
            this.InitializeComponent();
        }

        public UserModel CurrentUser
        {
            get { return (UserModel)GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("CurrentUser", typeof(UserModel), typeof(LauncherControl), new PropertyMetadata(null));

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null)
            {
                var list = sender as ListView;
                switch (list.SelectedIndex)
                {
                    case 0:
                        {
                            await App.Navigate(typeof(ProfilePage), CurrentUser);
                            break;
                        }
                    case 1:
                        {
                            await App.Navigate(typeof(FriendsPage), CurrentUser);
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

                list.SelectedIndex = -1;
            }
        }
    }
}
