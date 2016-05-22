using Epiphany.Strings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class CollapsableText : UserControl
    {
        private static int minLinesDefault = 7;
        private static int maxLinesDefault = 300;

        public CollapsableText()
        {
            this.InitializeComponent();

            if (StartCollapsed)
            {
                descriptionLabel.MaxLines = MinLines;
                expandCollapseButton.Content = AppStrings.CollapsableTextMoreButtonText;
            }
            else
            {
                descriptionLabel.MaxLines = MaxLines;
                expandCollapseButton.Content = AppStrings.CollapsableTextLessButtonText;
            }

            if (string.IsNullOrEmpty(Text))
            {
                expandCollapseButton.Visibility = Visibility.Collapsed;
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CollapsableText), new PropertyMetadata(string.Empty, OnTextChanged));

        public int MinLines
        {
            get { return (int)GetValue(MinLinesProperty); }
            set { SetValue(MinLinesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinLines.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinLinesProperty =
            DependencyProperty.Register("MinLines", typeof(int), typeof(CollapsableText), new PropertyMetadata(minLinesDefault, UpdateLines));

        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxLines.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxLinesProperty =
            DependencyProperty.Register("MaxLines", typeof(int), typeof(CollapsableText), new PropertyMetadata(maxLinesDefault, UpdateLines));

        public bool StartCollapsed
        {
            get { return (bool)GetValue(StartCollapsedProperty); }
            set { SetValue(StartCollapsedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartCollapsed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartCollapsedProperty =
            DependencyProperty.Register("StartCollapsed", typeof(bool), typeof(CollapsableText), new PropertyMetadata(true));


        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (descriptionLabel.MaxLines == MinLines)
            {
                // Expand
                descriptionLabel.MaxLines = MaxLines;
                button.Content = AppStrings.CollapsableTextLessButtonText;
            }
            else
            {
                // Collapse
                descriptionLabel.MaxLines = MinLines;
                button.Content = AppStrings.CollapsableTextMoreButtonText;
            }
        }

        private static void UpdateLines(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var collapsableTextControl = d as CollapsableText;

            if (e.Property == MinLinesProperty || e.Property == MaxLinesProperty)
            {
                collapsableTextControl.descriptionLabel.MaxLines = (int)e.NewValue;
            }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var collapsableTextControl = d as CollapsableText;

            if (string.IsNullOrEmpty(collapsableTextControl.Text))
            {
                collapsableTextControl.expandCollapseButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                collapsableTextControl.expandCollapseButton.Visibility = Visibility.Visible;
            }
        }
    }
}
