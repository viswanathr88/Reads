using System;

namespace Epiphany.ViewModel.Commands
{
    public abstract class Command<T1, T2> : CommandBase<T1, T2>
    {
        public abstract override bool CanExecute(T2 param);

        protected abstract T1 ExecuteSync(T2 param);

        public override void Execute(T2 param)
        {
            CommandExecutionState state = CommandExecutionState.Failure;
            CancelEventArgs args = new CancelEventArgs(false);
            RaiseExecuting(args);
            if (!args.Cancel)
            {
                try
                {
                    Result = ExecuteSync(param);
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
