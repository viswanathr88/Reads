using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class Section : UserControl
    {
        public Section()
        {
            this.InitializeComponent();
        }

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(Section), new PropertyMetadata(string.Empty));

        public object SectionContent
        {
            get { return (object)GetValue(SectionContentProperty); }
            set { SetValue(SectionContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SectionContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SectionContentProperty =
            DependencyProperty.Register("SectionContent", typeof(object), typeof(Section), new PropertyMetadata(null));

    }
}
