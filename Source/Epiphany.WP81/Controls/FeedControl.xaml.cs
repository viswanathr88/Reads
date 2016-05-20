using Epiphany.Logging;
using Epiphany.ViewModel.Items;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class FeedControl : UserControl
    {
        public FeedControl()
        {
            this.InitializeComponent();
        }

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable), typeof(FeedControl), new PropertyMetadata(null));

        public Frame Frame
        {
            get { return (Frame)GetValue(FrameProperty); }
            set { SetValue(FrameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Frame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrameProperty =
            DependencyProperty.Register("Frame", typeof(Frame), typeof(FeedControl), new PropertyMetadata(null));


        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(FeedControl), new PropertyMetadata(false));

        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEmpty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEmptyProperty =
            DependencyProperty.Register("IsEmpty", typeof(bool), typeof(FeedControl), new PropertyMetadata(false));

        public string EmptyFeedMessage
        {
            get { return (string)GetValue(EmptyFeedMessageProperty); }
            set { SetValue(EmptyFeedMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmptyFeedMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmptyFeedMessageProperty =
            DependencyProperty.Register("EmptyFeedMessage", typeof(string), typeof(FeedControl), new PropertyMetadata(string.Empty));

        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(FeedControl), new PropertyMetadata(null));

        private void User_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (sender == null)
            {
                Logger.LogError("sender is not framework element");
                return;
            }

            var feedItemVM = element.DataContext as IFeedItemViewModel;
            if (feedItemVM == null)
            {
                Logger.LogError("DataContext is not IFeedItemViewModel");
                return;
            }

            var parameter = (feedItemVM.User as UserItemViewModel).Item;

            // Navigate to Profile
            var frame = Window.Current.Content as Frame;
            frame.Navigate(typeof(ProfilePage), parameter, new SlideNavigationTransitionInfo());
        }
    }

}
