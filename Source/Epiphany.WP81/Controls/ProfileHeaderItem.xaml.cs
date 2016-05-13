using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class ProfileHeaderItem : UserControl
    {
        public ProfileHeaderItem()
        {
            this.InitializeComponent();
            Opacity = 0;
        }

        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconGlyph.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconGlyphProperty =
            DependencyProperty.Register("IconGlyph", typeof(string), typeof(ProfileHeaderItem), new PropertyMetadata(string.Empty));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ProfileHeaderItem), new PropertyMetadata(string.Empty, OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement sender = d as FrameworkElement;
            string newValue = e.NewValue.ToString();

            if (string.IsNullOrEmpty(newValue))
            {
                sender.Opacity = 0;
            }
            else
            {
                sender.Opacity = 1;
            }
        }
    }
}
