using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Epiphany.View.Behaviors
{
    /// <summary>
    /// Custom WebBrowser behavior that executes a command when the Navigating event is raised by the WebBrowser
    /// </summary>
    public class BrowserNavigatingCommandBehavior : Behavior<WebBrowser>
    {
        /// <summary>
        /// Command to execute
        /// </summary>
        /// <remarks>
        /// This will be executed with the Uri as the parameter
        /// </remarks>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BrowserNavigatingCommandBehavior), new PropertyMetadata(null));

        /// <summary>
        /// Called when the behavior is attached to the WebBrowser
        /// </summary>
        /// <remarks>
        /// Start listening for Navigating events
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Navigating += OnBrowserNavigating;
        }

        /// <summary>
        /// Called when the behavior is detached from the WebBrowser
        /// </summary>
        /// <remarks>
        /// Stop listening for Navigating events
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Navigating -= OnBrowserNavigating;
        }
        /// <summary>
        /// Navigating event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        private void OnBrowserNavigating(object sender, NavigatingEventArgs e)
        {
            if (Command != null && Command.CanExecute(e.Uri))
            {
                Command.Execute(e.Uri);
            }
        }
    }
}
