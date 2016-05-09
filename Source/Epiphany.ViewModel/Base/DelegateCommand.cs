using System;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private Action action;

        public DelegateCommand(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            this.action = action;
        }

        public event EventHandler CanExecuteChanged;
        private void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action.Invoke();
            }
        }
    }
}
