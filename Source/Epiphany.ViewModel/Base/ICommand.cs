using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    public interface ICommand<T1, T2> : ICommand
    {
        T1 Result
        {
            get;
        }

        bool CanExecute(T2 param);

        void Execute(T2 param);

        Exception Error
        {
            get;
        }

        event EventHandler<CancelEventArgs> Executing;
        event EventHandler<ExecutedEventArgs> Executed;
    }
}
