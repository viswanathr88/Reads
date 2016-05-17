using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Epiphany.View.Controls
{
    public sealed partial class BusyIndicatorTextButton : UserControl
    {
        public BusyIndicatorTextButton()
        {
            this.InitializeComponent();
            label.Visibility = Visibility.Visible;
            busyIndicator.Visibility = Visibility.Collapsed;
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BusyIndicatorTextButton), new PropertyMetadata(0));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(BusyIndicatorTextButton), new PropertyMetadata(0));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(BusyIndicatorTextButton), new PropertyMetadata(string.Empty));

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBusy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.Register("IsBusy", typeof(bool), typeof(BusyIndicatorTextButton), new PropertyMetadata(false, OnIsBusyChanged));


        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconGlyph.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconGlyphProperty =
            DependencyProperty.Register("IconGlyph", typeof(string), typeof(BusyIndicatorTextButton), new PropertyMetadata(string.Empty));

        private static void OnIsBusyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BusyIndicatorTextButton button = d as BusyIndicatorTextButton;

            if (e.NewValue.Equals(true))
            {
                button.contentPanel.Visibility = Visibility.Collapsed;
                button.busyIndicator.Visibility = Visibility.Visible;
            }
            else
            {
                button.contentPanel.Visibility = Visibility.Visible;
                button.busyIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}
