using Epiphany.Logging;
using Epiphany.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// Base class for all viewmodels that load data from model
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    public abstract class DataViewModel<TParam> : ViewModelBase, IDataViewModel<TParam>
    {
        private readonly IDictionary<ICommand, Action<ExecutedEventArgs>> commands;

        private bool isLoading;
        private bool isLoaded;
        private object error;

        public event EventHandler<EventArgs> Done;
        protected void RaiseDone() => Done?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Create an instance of DataViewModel
        /// </summary>
        public DataViewModel()
        {
            this.commands = new Dictionary<ICommand, Action<ExecutedEventArgs>>();
        }
        /// <summary>
        /// Gets whether the viewmodel is loading data
        /// </summary>
        public bool IsLoading
        {
            get { return this.isLoading; }
            protected set
            {
                if (this.isLoading == value) return;
                this.isLoading = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Gets whether the viewmodel has loaded data
        /// </summary>
        public bool IsLoaded
        {
            get { return this.isLoaded; }
            protected set
            {
                if (this.isLoaded == value) return;
                this.isLoaded = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Gets the error
        /// </summary>
        public object Error
        {
            get
            {
                return this.error;
            }
            protected set
            {
                if (this.error == value) return;
                this.error = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="parameter">input param</param>
        /// <returns></returns>
        public async Task LoadAsync(object parameter)
        {
            try
            {
                if (typeof(TParam) != typeof(VoidType))
                {
                    // Perform parameter validation
                    if (parameter == null)
                    {
                        Logger.LogError("Parameter is null");
                        throw new ArgumentNullException(nameof(parameter));
                    }

                    // Check parameter type
                    if (!(parameter is TParam))
                    {
                        Logger.LogError("Incorrect type passed to load. Type = " + parameter.GetType());
                        throw new ArgumentOutOfRangeException(nameof(parameter));
                    }

                    TParam param = (TParam)parameter;
                    Parameter = param;
                }

                Logger.LogDebug("About to call LoadAsync after parameter validation");
                await LoadAsync(Parameter);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Error = ex;
            }
        }
        /// <summary>
        /// Load with typesafe parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract Task LoadAsync(TParam parameter);
        /// <summary>
        /// Gets the input parameter
        /// </summary>
        protected TParam Parameter
        {
            get;
            private set;
        }
        /// <summary>
        /// Register a command
        /// </summary>
        /// <param name="command">command to register</param>
        /// <param name="callback">callback when command execution completes</param>
        protected void RegisterCommand(ICommandEx command, Action<ExecutedEventArgs> callback)
        {
            if (command == null || callback == null)
            {
                throw new ArgumentNullException("command or callback");
            }

            if (this.commands.ContainsKey(command))
            {
                Logger.LogError(string.Format("{0} - {1} already registered", GetType(), command.GetType()));
                return;
            }

            Logger.LogInfo(string.Format("{0} Registering Command {1}", GetType(), command.GetType()));

            command.Executing += OnCmdExecuting;
            command.Executed += OnCommandExecuted;

            this.commands.Add(command, callback);
        }
        /// <summary>
        /// Deregister a command
        /// </summary>
        /// <param name="command"></param>
        protected void DeregisterCommand(ICommandEx command)
        {
            if (this.commands.ContainsKey(command))
            {
                command.Executing -= OnCmdExecuting;
                command.Executed -= OnCommandExecuted;

                this.commands.Remove(command);

                Logger.LogInfo(string.Format("{0} - Deregistered {1}", GetType(), command.GetType()));
            }
            else
            {
                Logger.LogWarn(string.Format("{0} - Deregistering a command {1} that has not been registered", 
                    GetType(), command.GetType()));
            }
        }
        /// <summary>
        /// Method execute when command begins execution
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event args</param>
        protected virtual void OnCmdExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }
        /// <summary>
        /// Callback when the command has finished execution
        /// </summary>
        /// <param name="sender">event source</param>
        /// <param name="e">event args</param>
        private void OnCommandExecuted(object sender, ExecutedEventArgs e)
        {
            if (sender == null)
            {
                Logger.LogError(string.Format("{0} sender cannot be null", GetType()));
                return;
            }

            ICommand command = sender as ICommand;
            if (command == null)
            {
                Logger.LogError(string.Format("{0} - command is null", GetType()));
                return;
            }

            if (!commands.ContainsKey(command))
            {
                Logger.LogError(string.Format("{0} - Command {1} not found in collection", GetType(), command.GetType()));
                return;
            }

            try
            {
                this.commands[command].Invoke(e);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Error = ex;
            }
        }
    }
}
