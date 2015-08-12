using Epiphany.Logging;
using System;

namespace Epiphany.ViewModel.Commands
{
    abstract class CommandBase<T> : ICommand<T>
    {
        public abstract bool CanExecute(T param);

        public abstract void Execute(T param);

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;

            if (!(parameter is T))
                return false;

            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Log.Instance.Info(string.Format("{0} - Parameter = object", GetType()));
            if (CanExecute(parameter))
            {
                T param = GetSafeParam(parameter);
                Execute(param);
            }
        }

        public Exception Error
        {
            get;
            protected set;
        }

        public event EventHandler<CancelEventArgs> Executing;
        public event EventHandler<ExecutedEventArgs> Executed;
        public event EventHandler CanExecuteChanged;

        protected void RaiseExecuting(CancelEventArgs args)
        {
            if (Executing != null)
            {
                Log.Instance.Info(GetType().ToString());
                Executing(this, args);
            }
        }

        protected void RaiseExecuted(CommandExecutionState state)
        {
            if (Executed != null)
            {
                Log.Instance.Info(string.Format("{0} - ExecutionState = {1}", GetType(), state));
                Executed(this, new ExecutedEventArgs(state));
            }
        }

        protected void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        protected T GetSafeParam(object parameter)
        {
            T param = default(T);

            if (parameter == null)
                param = default(T);
            else
                param = (T)parameter;

            return param;
        }
    }
}
