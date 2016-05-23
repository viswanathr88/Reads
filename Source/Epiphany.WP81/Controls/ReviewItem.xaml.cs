using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.WP81;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class ReviewItem : UserControl
    {
        public ReviewItem()
        {
            this.InitializeComponent();
        }

        public string UserImage
        {
            get { return (string)GetValue(UserImageProperty); }
            set { SetValue(UserImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserImageProperty =
            DependencyProperty.Register("UserImage", typeof(string), typeof(ReviewItem), new PropertyMetadata(string.Empty));


        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Username.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(ReviewItem), new PropertyMetadata(string.Empty));

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(int), typeof(ReviewItem), new PropertyMetadata(0));


        public string Body
        {
            get { return (string)GetValue(BodyProperty); }
            set { SetValue(BodyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Body.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BodyProperty =
            DependencyProperty.Register("Body", typeof(string), typeof(ReviewItem), new PropertyMetadata(string.Empty));

        public UserModel User
        {
            get { return (UserModel)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for User.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserProperty =
            DependencyProperty.Register("User", typeof(UserModel), typeof(ReviewItem), new PropertyMetadata(null));


        private async void User_Click(object sender, RoutedEventArgs e)
        {
            if (User == null)
            {
                Logger.LogError("User is null. Cannot navigate");
            }

            await App.Navigate(typeof(ProfilePage), User, new SlideNavigationTransitionInfo());
        }
    }
}
