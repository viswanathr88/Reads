using System;

namespace Epiphany.ViewModel.Commands
{

    abstract class Command<T> : CommandBase<T>
    {
        public abstract override bool CanExecute(T param);

        protected abstract void Run(T param);

        public override void Execute(T param)
        {
            if (CanExecute(param))
            {
                CommandExecutionState state = CommandExecutionState.Failure;
                CancelEventArgs args = new CancelEventArgs(false);
                RaiseExecuting(args);
                if (!args.Cancel)
                {
                    try
                    {
                        Run(param);
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


    abstract class Command<T1, T2> : Command<T2>, ICommand<T1, T2>
    {

        public T1 Result
        {
            get;
            protected set;
        }

        public abstract override bool CanExecute(T2 param);

        protected abstract override void Run(T2 param);
    }

    abstract class Command : Command<VoidType>
    {

        protected abstract bool CanExecute();

        protected abstract void Run();

        public override bool CanExecute(VoidType param)
        {
            return CanExecute();
        }

        protected override void Run(VoidType param)
        {
            Run();
        }
    }

}
