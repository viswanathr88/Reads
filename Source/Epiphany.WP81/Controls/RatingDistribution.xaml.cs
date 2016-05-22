using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class RatingDistribution : UserControl
    {
        public RatingDistribution()
        {
            this.InitializeComponent();
        }

        public double AverageRating
        {
            get { return (double)GetValue(AverageRatingProperty); }
            set { SetValue(AverageRatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AverageRating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AverageRatingProperty =
            DependencyProperty.Register("AverageRating", typeof(double), typeof(RatingDistribution), new PropertyMetadata(0));


        public int RatingsCount
        {
            get { return (int)GetValue(RatingsCountProperty); }
            set { SetValue(RatingsCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RatingsCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingsCountProperty =
            DependencyProperty.Register("RatingsCount", typeof(int), typeof(RatingDistribution), new PropertyMetadata(0));


        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable), typeof(RatingDistribution), new PropertyMetadata(null));

        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Glyph.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GlyphProperty =
            DependencyProperty.Register("Glyph", typeof(string), typeof(RatingDistribution), new PropertyMetadata(string.Empty));

    }
}
