using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Epiphany.Controls
{
    public class HamburgerMenu : ContentControl
    {
        private ContentPresenter LeftPanePresenter { get; set; }
        private Rectangle MainPaneRectangle { get; set; }

        public HamburgerMenu()
        {
            this.DefaultStyleKey = typeof(HamburgerMenu);
        }

        protected override void OnApplyTemplate()
        {
            // Find the left pane in the control template and store a reference
            this.LeftPanePresenter = this.GetTemplateChild("leftPanePresenter") as ContentPresenter;
            this.MainPaneRectangle = this.GetTemplateChild("mainPaneRectangle") as Rectangle;

            if (this.MainPaneRectangle != null)
                this.MainPaneRectangle.Tapped += (sender, e) => { this.IsLeftPaneOpen = false; };

            this.LeftPanePresenter.Loaded += (sender, e) => { this.SetLeftPanePresenterX(); };

            base.OnApplyTemplate();
        }

        private void SetLeftPanePresenterX()
        {
            // Set the X position of the left pane content presenter to the negative of the pane so that it's off to the left of the screen when closed
            if (this.LeftPanePresenter != null)
            {
                this.LeftPanePresenter.RenderTransform = new CompositeTransform()
                {
                    TranslateX = -this.LeftPanePresenter.ActualWidth
                };
            }
        }

        public static readonly DependencyProperty LeftPaneProperty = DependencyProperty.Register("LeftPane", typeof(UIElement), typeof(HamburgerMenu), new PropertyMetadata(null));
        public UIElement LeftPane
        {
            get { return (UIElement)GetValue(LeftPaneProperty); }
            set { SetValue(LeftPaneProperty, value); }
        }

        public static readonly DependencyProperty IsLeftPaneOpenProperty = DependencyProperty.Register("IsLeftPaneOpen", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(false, new PropertyChangedCallback(OnIsLeftPaneOpenChanged)));
        public bool IsLeftPaneOpen
        {
            get { return (bool)GetValue(IsLeftPaneOpenProperty); }
            set { SetValue(IsLeftPaneOpenProperty, value); }
        }
        private static void OnIsLeftPaneOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var ctrl = sender as HamburgerMenu;
            if (ctrl != null)
            {
                if (ctrl.LeftPane != null)
                {
                    // Change to appropriate view state when the the IsLeftPaneOpen is toggled
                    var value = (bool)args.NewValue;
                    if (value)
                        VisualStateManager.GoToState(ctrl, "OpenLeftPane", true);
                    else
                        VisualStateManager.GoToState(ctrl, "CloseLeftPane", true);
                }
            }
        }
    }
}
