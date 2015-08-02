using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Epiphany.View.Behaviors
{
    /// <summary>
    /// Custom behavior that executes a command when the Pivot's Current Index changes to a particular index
    /// </summary>
    /// <remarks>
    /// When the profile swipes on a Pivot control, it's SelectedIndex property changes. This behavior will look
    /// for a particular index to become active and when it does, it executes the command with the parameter
    /// </remarks>
    public class PivotIndexChangeBehavior : Behavior<Pivot>
    {
        /// <summary>
        /// The command to be executed
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        /// <summary>
        /// The parameter to the command
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        /// <summary>
        /// The index on which the Command should be executed
        /// </summary>
        public int DesiredIndex
        {
            get { return (int)GetValue(DesiredIndexProperty); }
            set { SetValue(DesiredIndexProperty, value); }
        }
        /// <summary>
        /// Gets whether the command will be executed
        /// </summary>
        public bool ShouldExecuteCommand
        {
            get { return (bool)GetValue(ShouldExecuteCommandProperty); }
            set { SetValue(ShouldExecuteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShouldExecuteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShouldExecuteCommandProperty =
            DependencyProperty.Register("ShouldExecuteCommand", typeof(bool), typeof(PivotIndexChangeBehavior), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(PivotIndexChangeBehavior), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(PivotIndexChangeBehavior), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for DesiredIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DesiredIndexProperty =
            DependencyProperty.Register("DesiredIndex", typeof(int), typeof(PivotIndexChangeBehavior), new PropertyMetadata(0));

        /// <summary>
        /// Called when the behavior is attached to the pivot
        /// </summary>
        /// <remarks>
        /// Start listening for SelectionChanged events
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }
        /// <summary>
        /// Called when the behavior is detached from the Pivot
        /// </summary>
        /// <remarks>
        /// Stop listening for SelectionChanged events
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }
        /// <summary>
        /// SelectionChanged event handler
        /// </summary>
        /// <uri name="sender">sender</uri>
        /// <uri name="e">args</uri>
        void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Pivot pivot = sender as Pivot;
            if (pivot == null) return;
            //
            // If the selected index is the desired index, execute the command
            //
            if (pivot.SelectedIndex == DesiredIndex && ShouldExecuteCommand)
            {
                if (Command != null && Command.CanExecute(CommandParameter))
                {
                    Command.Execute(CommandParameter);
                }
            }
        }
    }
}
