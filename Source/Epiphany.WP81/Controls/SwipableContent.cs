using System;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace Epiphany.View.Controls
{

    public enum SwipeDirection
    {
        LeftSwipe,
        RightSwipe,
        Default
    };

    public class SwipeEventArgs : EventArgs
    {
        private SwipeDirection direction;

        public SwipeEventArgs(SwipeDirection direction)
        {
            this.direction = direction;
        }

        public SwipeDirection Direction
        {
            get
            {
                return this.direction;
            }
        }
    }

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

        public ICommand LeftCommand
        {
            get { return (ICommand)GetValue(LeftCommandProperty); }
            set { SetValue(LeftCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftCommandProperty =
            DependencyProperty.Register("LeftCommand", typeof(ICommand), typeof(SwipableContent), new PropertyMetadata(null));


        public ICommand RightCommand
        {
            get { return (ICommand)GetValue(RightCommandProperty); }
            set { SetValue(RightCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RightCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightCommandProperty =
            DependencyProperty.Register("RightCommand", typeof(ICommand), typeof(SwipableContent), new PropertyMetadata(null));


        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SwipableContent), new PropertyMetadata(null));

        public bool SwipeEnabled
        {
            get { return (bool)GetValue(SwipeEnabledProperty); }
            set { SetValue(SwipeEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SwipeEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwipeEnabledProperty =
            DependencyProperty.Register("SwipeEnabled", typeof(bool), typeof(SwipableContent), new PropertyMetadata(true));

        public event EventHandler<SwipeEventArgs> SwipeCompleted;
        private void RaiseSwipeCompleted(SwipeDirection direction) => SwipeCompleted?.Invoke(this, new SwipeEventArgs(direction));


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

            if (!SwipeEnabled)
            {
                return;
            }
            
            if (Math.Abs(e.Cumulative.Translation.X) > 50)
            {
                SwipeDirection direction = DirectionOfManipulation(e.Cumulative.Translation);
                RaiseSwipeCompleted(direction);

                if (direction == SwipeDirection.RightSwipe)
                {
                    if (LeftCommand != null && LeftCommand.CanExecute(CommandParameter))
                    {
                        LeftCommand.Execute(CommandParameter);
                    }
                }
                else
                {
                    if (RightCommand != null && RightCommand.CanExecute(CommandParameter))
                    {
                        RightCommand.Execute(CommandParameter);
                    }
                }
            }
        }

        private void SwipableContent_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (SwipeEnabled)
            {
                SetVisualStateForManipulation(e.Cumulative.Translation);
                TranslateContent(e.Cumulative.Translation.X);
            }
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
