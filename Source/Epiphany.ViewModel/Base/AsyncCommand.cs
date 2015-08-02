using Epiphany.Logging;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    abstract class AsyncCommand<T> : CommandBase<T>, IAsyncCommand<T>
    {
        public abstract override bool CanExecute(T param);

        protected abstract Task RunAsync(T param);

        public async override void Execute(T param)
        {
            await ExecuteAsync(param);
        }

        public async Task ExecuteAsync(T param)
        {
            Error = null;
            if (CanExecute(param))
            {
                CommandExecutionState state = CommandExecutionState.Failure;
                CancelEventArgs args = new CancelEventArgs(false);
                RaiseExecuting(args);
                if (!args.Cancel)
                {
                    try
                    {
                        await RunAsync(param);
                        state = CommandExecutionState.Success;
                    }
                    catch (Exception ex)
                    {
                        Error = ex;
                        state = CommandExecutionState.Failure;
                        Log.Instance.Error(string.Format("{0} Stack - {1}", ex.Message, ex.StackTrace));
                    }
                }
                else
                {
                    state = CommandExecutionState.Cancelled;
                    Log.Instance.Warn("Execute was cancelled");
                }
                RaiseExecuted(state);
            }
        }
    }


    abstract class AsyncCommand : AsyncCommand<VoidType>
    {
        protected abstract bool CanExecute();

        protected abstract Task RunAsync();

        public override bool CanExecute(VoidType param)
        {
            return CanExecute();
        }

        protected async override Task RunAsync(VoidType param)
        {
            await RunAsync();
        }
    }


    abstract class AsyncCommand<T1, T2> : AsyncCommand<T2>, IAsyncCommand<T1, T2>
    {
        public T1 Result
        {
            get;
            protected set;
        }

        public abstract override bool CanExecute(T2 param);

        protected abstract override Task RunAsync(T2 param);
    }
}
