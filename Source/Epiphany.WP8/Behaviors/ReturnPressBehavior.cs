using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Epiphany.View.Behaviors
{
    /// <summary>
    /// Custom behavior that executes a command when the return key is pressed on a TextBox
    /// </summary>
    /// <remarks>
    /// This is useful for binding
    /// </remarks>
    public class ReturnPressBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// The Command property to execute 
        /// </summary>
        /// <remarks>
        /// Set this command from xaml
        /// </remarks>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        /// <summary>
        /// The parameter to the command
        /// </summary>
        /// <remarks>
        /// If there no parameters to the command, this should be null
        /// </remarks>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(ReturnPressBehavior), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ReturnPressBehavior), new PropertyMetadata(null));

        /// <summary>
        /// Called when the behavior is attached to the Textbox
        /// </summary>
        /// <remarks>
        /// Start listening for KeyUp events
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyUp += OnKeyUp;
        }
        /// <summary>
        /// Called when the behavior is detached from the TextBox
        /// </summary>
        /// <remarks>
        /// Stop listening to KeyUp events
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.KeyUp -= OnKeyUp;
        }
        /// <summary>
        /// Callback for KeyUp event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        private void OnKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
            }
        }
    }
}
