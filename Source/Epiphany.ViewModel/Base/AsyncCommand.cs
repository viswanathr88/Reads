using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    public abstract class AsyncCommand<T1, T2> : CommandBase<T1, T2>
    {
        public abstract override bool CanExecute(T2 param);

        protected abstract Task<T1> ExecuteAsync(T2 param);

        public async override void Execute(T2 param)
        {
            CommandExecutionState state = CommandExecutionState.Failure;
            CancelEventArgs args = new CancelEventArgs(false);
            RaiseExecuting(args);
            if (!args.Cancel)
            {
                try
                {
                    Result = await ExecuteAsync(param);
                    state = CommandExecutionState.Success;
                }
                catch (Exception ex)
                {
                    Error = ex;
                    state = CommandExecutionState.Failure;
                }
            }
            else
            {
                state = CommandExecutionState.Cancelled;
            }
            RaiseExecuted(state);
        }
    }
}
