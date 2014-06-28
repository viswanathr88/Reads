using System;

namespace Epiphany.ViewModel.Commands
{
    public enum CommandExecutionState 
    {
        Success,
        Failure,
        Cancelled
    };
    
    public class ExecutedEventArgs : EventArgs
    {
        private CommandExecutionState state;

        public ExecutedEventArgs(CommandExecutionState state)
        {
            this.state = state;
        }

        public CommandExecutionState State
        {
            get { return this.state; }
        }
    }
}
