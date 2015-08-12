using Epiphany.Logging;
using Epiphany.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public abstract class DataViewModel : ViewModelBase, IDataViewModel
    {
        private readonly IDictionary<ICommand, Action<ExecutedEventArgs>> commands;

        private bool isLoading;
        private bool isLoaded;
        private object error;

        public DataViewModel()
        {
            this.commands = new Dictionary<ICommand, Action<ExecutedEventArgs>>();
        }

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

        public bool IsLoaded
        {
            get { return this.isLoaded; }
            protected set
            {
                if (this.isLoaded == value) return;
                this.isLoaded = value;
                RaisePropertyChanged(() => IsLoaded);
            }
        }

        public abstract Task LoadAsync();


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

        protected void RegisterCommand(ICommandEx command, Action<ExecutedEventArgs> callback)
        {
            if (command == null || callback == null)
            {
                throw new ArgumentNullException("command or callback");
            }

            if (this.commands.ContainsKey(command))
            {
                Log.Instance.Error(string.Format("{0} - {1} already registered", GetType(), command.GetType()));
                return;
            }

            Log.Instance.Info(string.Format("{0} Registering Command {1}", GetType(), command.GetType()));

            command.Executing += OnCmdExecuting;
            command.Executed += OnCommandExecuted;

            this.commands.Add(command, callback);
        }

        protected void DeRegisterCommand(ICommandEx command)
        {
            if (this.commands.ContainsKey(command))
            {
                command.Executing -= OnCmdExecuting;
                command.Executed -= OnCommandExecuted;

                this.commands.Remove(command);

                Log.Instance.Info(string.Format("{0} - Deregistered {1}", GetType(), command.GetType()));
            }
            else
            {
                Log.Instance.Warn(string.Format("{0} - Deregistering a command {1} that has not been registered", 
                    GetType(), command.GetType()));
            }
        }

        protected virtual void OnCmdExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnCommandExecuted(object sender, ExecutedEventArgs e)
        {
            if (sender == null)
            {
                Log.Instance.Error(string.Format("{0} sender cannot be null", GetType()));
                return;
            }

            ICommand command = sender as ICommand;
            if (command == null)
            {
                Log.Instance.Error(string.Format("{0} - command is null", GetType()));
                return;
            }

            if (!commands.ContainsKey(command))
            {
                Log.Instance.Error(string.Format("{0} - Command {1} not found in collection", GetType(), command.GetType()));
                return;
            }

            try
            {
                this.commands[command].Invoke(e);
            }
            catch (Exception ex)
            {
                Error = ex;
                Log.Instance.Error(string.Format("{0} - {1} - {2} - {3}", GetType(), ex, ex.Message, ex.StackTrace));
            }
        }
    }
}
