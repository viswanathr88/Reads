using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Epiphany.Controls
{

    public enum SwipeDirection
    {
        LeftSwipe,
        RightSwipe,
        Default
    };

    [ContentProperty(Name = "Content")]
    public sealed class SwipableContent : Control
    {
        FrameworkElement contentElement;
        FrameworkElement leftContentElement;
        FrameworkElement rightContentElement;

        public SwipableContent()
        {
            this.DefaultStyleKey = typeof(SwipableContent);
            this.ManipulationMode = ManipulationModes.System | ManipulationModes.TranslateX;
            this.ManipulationDelta += SwipableContent_ManipulationDelta;
            this.ManipulationCompleted += SwipableContent_ManipulationCompleted;
        }

        public object LeftContent
        {
            get { return (object)GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftContentProperty =
            DependencyProperty.Register("LeftContent", typeof(object), typeof(SwipableContent), new PropertyMetadata(null));


        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(SwipableContent), new PropertyMetadata(null));


        public object RightContent
        {
            get { return (object)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RightContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightContentProperty =
            DependencyProperty.Register("RightContent", typeof(object), typeof(SwipableContent), new PropertyMetadata(null));


        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.contentElement = GetTemplateChild("contentPresenter") as FrameworkElement;
            this.leftContentElement = GetTemplateChild("leftContentPresenter") as FrameworkElement;
            this.rightContentElement = GetTemplateChild("rightContentPresenter") as FrameworkElement;
        }

        private void SwipableContent_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Default", true);
            TranslateContent(0);
        }

        private void SwipableContent_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            SetVisualStateForManipulation(e.Cumulative.Translation);
            TranslateContent(e.Cumulative.Translation.X);
        }

        void SetVisualStateForManipulation(Point p)
        {
            var direction = this.DirectionOfManipulation(p);
            VisualStateManager.GoToState(this, direction.ToString(), true);
        }

        SwipeDirection DirectionOfManipulation(Point p)
        {
            SwipeDirection d = SwipeDirection.Default;

            if (p.X != 0)
            {
                d = p.X < 0 ? SwipeDirection.LeftSwipe : SwipeDirection.RightSwipe;
            }
            return d;
        }

        private void TranslateContent(double x)
        {
            if (this.contentElement != null)
            {
                TranslateTransform transform = (this.contentElement.RenderTransform as TranslateTransform);

                if (transform == null)
                {
                    transform = new TranslateTransform();
                    this.contentElement.RenderTransform = transform;
                }

                transform.X = x;

                if (x > 0)
                {
                    leftContentElement.Width = x;
                }
                else if (x < 0)
                {
                    rightContentElement.Width = Math.Abs(x);
                }

            }
        }
    }
}
