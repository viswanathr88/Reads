using Epiphany.Logging;
using System;

namespace Epiphany.ViewModel.Commands
{
    public abstract class CommandBase<T1, T2> : ICommand<T1, T2>
    {
        private readonly string name;

        public CommandBase()
        {
            this.name = GetType().ToString();
        }
        public abstract bool CanExecute(T2 param);
        public abstract void Execute(T2 param);

        public bool CanExecute(object parameter)
        {
            // If the type is not voidtype, perform
            // type checking
            if (typeof(T2) != typeof(VoidType))
            {
                if (parameter == null)
                    return false;

                if (!(parameter is T2))
                    return false;
            }

            return CanExecute((T2)parameter);
        }

        public void Execute(object parameter)
        {
            Error = null;
            if (CanExecute(parameter))
            {
                T2 param = GetSafeParam(parameter);
                Execute(param);
            }
        }

        public Exception Error
        {
            get;
            protected set;
        }


        public T1 Result
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
                Log.Instance.Debug("");
                Executing(this, args);
            }
        }

        protected void RaiseExecuted(CommandExecutionState state)
        {
            if (Executed != null)
            {
                Log.Instance.Debug(state.ToString());
                Executed(this, new ExecutedEventArgs(state));
            }
        }

        protected void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        protected string GetName()
        {
            return this.name;
        }

        private T2 GetSafeParam(object parameter)
        {
            T2 param = default(T2);

            if (typeof(T2) == typeof(VoidType) && parameter == null)
                param = default(T2);
            else
                param = (T2)parameter;

            return param;
        }
    }
}
