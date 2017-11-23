using Epiphany.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class SignInControl : UserControl
    {
        public SignInControl()
        {
            this.InitializeComponent();
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(nameof(Message), typeof(string), typeof(SignInControl), new PropertyMetadata(string.Empty));

        private void OnLoginClicked(object sender, RoutedEventArgs e)
        {
            var frame = Window.Current.Content as Frame;

            if (frame != null)
            {
                frame.Navigate(typeof(LogonPage), VoidType.Empty);
            }
        }
    }
}
