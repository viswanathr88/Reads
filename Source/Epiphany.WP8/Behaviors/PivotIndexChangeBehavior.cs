using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Epiphany.View.Behaviors
{
    public class PivotIndexChangeBehavior : Behavior<Pivot>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public int DesiredIndex
        {
            get { return (int)GetValue(DesiredIndexProperty); }
            set { SetValue(DesiredIndexProperty, value); }
        }

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


        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Pivot pivot = sender as Pivot;
            if (pivot == null) return;

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
