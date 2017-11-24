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
                SetProperty(ref this.isLoading, value);
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
                SetProperty(ref this.isLoaded, value);
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
                SetProperty(ref this.error, value);
            }
        }
        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="parameter">input param</param>
        /// <returns></returns>
        public async Task LoadAsync(object parameter, bool fReload)
        {
            try
            {
                TParam param = default(TParam);

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

                param = (TParam)parameter;

                // Check if the parameters match. If they do, this ViewModel
                // has already been loaded, so skip loading
                if (!fReload && IsLoaded && object.Equals(Parameter, param))
                {
                    Logger.LogInfo("VM was loaded with same parameter. Skip Loading");
                    return;
                }

                // Set the parameter on the VM
                Parameter = param;

                Logger.LogDebug("Resetting ViewModel...");
                Reset();

                Logger.LogInfo("Loading ViewModel...");
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
        /// Reset method for ViewModel
        /// </summary>
        protected virtual void Reset()
        {
            Error = null;
            IsLoaded = false;
            IsLoading = false;
        }
        /// <summary>
        /// Gets the input parameter
        /// </summary>
        public TParam Parameter
        {
            get;
            protected set;
        }
        /// <summary>
        /// Gets the parameter
        /// </summary>
        object IDataViewModel.Parameter
        {
            get
            {
                return Parameter;
            }
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

            command.Executing += OnCommandExecuting;
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
                command.Executing -= OnCommandExecuting;
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
        protected virtual void OnCommandExecuting(object sender, CancelEventArgs e)
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
            IsLoading = false;

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
