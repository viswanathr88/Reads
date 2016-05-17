using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{

    public interface ICommandEx : ICommand, INotifyPropertyChanged
    {
        /// <summary>
        /// Event raised when the command begins execution
        /// </summary>
        event EventHandler<CancelEventArgs> Executing;
        /// <summary>
        /// Event fired when the command has finished execution
        /// </summary>
        event EventHandler<ExecutedEventArgs> Executed;
        /// <summary>
        /// Returns true if the command is executing
        /// </summary>
        bool IsExecuting { get; }
    }

    /// <summary>
    /// Represents a command interface with parameter T and no return type
    /// </summary>
    /// <typeparam name="T">Param of type T</typeparam>
    public interface ICommand<T> : ICommandEx
    {
        /// <summary>
        /// Return true if this command can execute for the given parameter
        /// </summary>
        /// <uri name="uri"></uri>
        /// <returns></returns>
        bool CanExecute(T param);
        /// <summary>
        /// Executes the command with given parameter
        /// </summary>
        /// <uri name="uri"></uri>
        void Execute(T param);
        /// <summary>
        /// Gets the error that occurred during command execution
        /// </summary>
        Exception Error
        {
            get;
        }
    }

    /// <summary>
    /// Represents a command interface with parameter T2 and return type T1
    /// </summary>
    /// <typeparam name="T1">Return type</typeparam>
    /// <typeparam name="T2">Parameter type</typeparam>
    public interface ICommand<T1, T2> : ICommand<T2>
    {
        /// <summary>
        /// Gets the result of type T1
        /// </summary>
        T1 Result
        {
            get;
        }
    }
}
