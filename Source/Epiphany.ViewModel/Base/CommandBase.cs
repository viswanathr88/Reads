using Epiphany.Logging;
using System;
using System.ComponentModel;

namespace Epiphany.ViewModel.Commands
{
    abstract class CommandBase<T> : ICommand<T>
    {
        private bool isExecuting;
        private Exception error;

        public abstract bool CanExecute(T param);

        public abstract void Execute(T param);

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
                return false;

            if (!(parameter is T))
                return false;

            if (IsExecuting)
            {
                return false;
            }

            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Logger.LogInfo(string.Format("{0} - Parameter = object", GetType()));
            if (CanExecute(parameter))
            {
                T param = GetSafeParam(parameter);
                Execute(param);
            }
        }

        public Exception Error
        {
            get
            {
                return this.error;
            }
            protected set
            {
                if (this.error != value)
                {
                    this.error = value;
                    RaisePropertyChanged(nameof(Error));
                }
            }
        }

        public bool IsExecuting
        {
            get
            {
                return this.isExecuting;
            }
            protected set
            {
                if (this.isExecuting == value) return;
                this.isExecuting = value;
                RaisePropertyChanged(nameof(IsExecuting));
            }
        }

        public event EventHandler<CancelEventArgs> Executing;
        protected void RaiseExecuting(CancelEventArgs args)
        {
            IsExecuting = true;
            RaiseCanExecuteChanged();
            if (Executing != null)
            {
                Logger.LogInfo(GetType().ToString());
                Executing(this, args);
            }
        }

        public event EventHandler<ExecutedEventArgs> Executed;
        protected void RaiseExecuted(CommandExecutionState state)
        {
            IsExecuting = false;
            RaiseCanExecuteChanged();
            if (Executed != null)
            {
                Logger.LogInfo(string.Format("{0} - ExecutionState = {1}", GetType(), state));
                Executed(this, new ExecutedEventArgs(state));
            }
        }

        public event EventHandler CanExecuteChanged;
        protected void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
