using System;

namespace Epiphany.ViewModel.Commands
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality 
    /// to other objects by invoking delegates. 
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    public sealed class RelayCommand : Command
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        /// <summary>
        /// Create a new instance of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute">Method to run when the command executes</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {

        }
        /// <summary>
        /// Create a new instance of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="exec">Method to run when the command executes</param>
        /// <param name="canExecute">Method to run to determine whether the command can be executed</param>
        public RelayCommand(Action exec, Func<bool> canExecute)
        {
            if (exec == null)
            {
                throw new ArgumentNullException(nameof(exec));
            }

            this._execute = exec;
            this._canExecute = canExecute;
        }
        /// <summary>
        /// Notify that can execute has changed
        /// </summary>
        public void NotifyCanExecuteChanged()
        {
            RaiseCanExecuteChanged();
        }
        /// <summary>
        /// Gets whether the command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, false otherwise</returns>
        protected override bool CanExecute()
        {
            return _canExecute == null ? true : _canExecute();
        }
        /// <summary>
        /// Run the command logic
        /// </summary>
        protected override void Run()
        {
            _execute();
        }
    }

    /// <summary>
    /// A command whose sole purpose is to relay its functionality 
    /// to other objects by invoking delegates. 
    /// The default return value for the CanExecute method is 'true'.
    /// </summary>
    public sealed class RelayCommand<TParam> : Command<TParam>
    {
        private readonly Action<TParam> _execute;
        private readonly Func<TParam, bool> _canExecute;

        /// <summary>
        /// Create a new instance of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="execute">Method to run when the command executes</param>
        public RelayCommand(Action<TParam> execute)
            : this(execute, null)
        {

        }
        /// <summary>
        /// Create a new instance of <see cref="RelayCommand"/>
        /// </summary>
        /// <param name="exec">Method to run when the command executes</param>
        /// <param name="canExecute">Method to run to determine whether the command can be executed</param>
        public RelayCommand(Action<TParam> exec, Func<TParam, bool> canExecute)
        {
            if (exec == null)
            {
                throw new ArgumentNullException(nameof(exec));
            }

            this._execute = exec;
            this._canExecute = canExecute;
        }
        /// <summary>
        /// Gets whether the command can be executed
        /// </summary>
        /// <returns>True if the command can be executed, false otherwise</returns>
        public override bool CanExecute(TParam param)
        {
            return _canExecute == null ? true : _canExecute(param);
        }
        /// <summary>
        /// Run the command logic
        /// </summary>
        protected override void Run(TParam param)
        {
            _execute(param);
        }
    }
}