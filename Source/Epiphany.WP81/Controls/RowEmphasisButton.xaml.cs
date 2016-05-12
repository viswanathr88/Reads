using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class RowEmphasisButton : UserControl
    {
        public RowEmphasisButton()
        {
            this.InitializeComponent();
        }

        public string FirstRowString
        {
            get { return (string)GetValue(FirstRowStringProperty); }
            set { SetValue(FirstRowStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FirstRowString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstRowStringProperty =
            DependencyProperty.Register("FirstRowString", typeof(string), typeof(RowEmphasisButton), new PropertyMetadata(string.Empty));


        public string SecondRowString
        {
            get { return (string)GetValue(SecondRowStringProperty); }
            set { SetValue(SecondRowStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondRowString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondRowStringProperty =
            DependencyProperty.Register("SecondRowString", typeof(string), typeof(RowEmphasisButton), new PropertyMetadata(string.Empty));


        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconGlyph.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconGlyphProperty =
            DependencyProperty.Register("IconGlyph", typeof(string), typeof(RowEmphasisButton), new PropertyMetadata(string.Empty));


        public bool PreferTextOverIcon
        {
            get { return (bool)GetValue(PreferTextOverIconProperty); }
            set { SetValue(PreferTextOverIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PreferTextOverIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreferTextOverIconProperty =
            DependencyProperty.Register("PreferTextOverIcon", typeof(bool), typeof(RowEmphasisButton), new PropertyMetadata(false));


    }
}
