using Microsoft.Phone.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Epiphany.View.Behaviors
{
    public class IncrementalLoadingBehavior : Behavior<LongListSelector>
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

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(IncrementalLoadingBehavior), new PropertyMetadata(null));

        

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(IncrementalLoadingBehavior), new PropertyMetadata(null));

        
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ItemRealized += OnItemRealized;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.ItemRealized -= OnItemRealized;
        }

        private void OnItemRealized(object sender, ItemRealizationEventArgs e)
        {
            var longListSelector = sender as LongListSelector;
            if (longListSelector == null)
                return;

            var item = e.Container.Content;
            var items = longListSelector.ItemsSource;
            var index = items.IndexOf(item);

            if (items.Count - index <= 1 && Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}
