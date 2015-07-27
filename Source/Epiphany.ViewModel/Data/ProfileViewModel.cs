using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public class ProfileViewModel : DataViewModel<int>
    {
        private readonly ICommand<ProfileModel, int> fetchProfileCommand;
        private readonly IUserService userService;
        private ProfileModel model;

        public ProfileViewModel(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.userService = userService;

            this.fetchProfileCommand = new FetchProfileCommand(userService);
            this.fetchProfileCommand.Executing += OnExecuting;
            this.fetchProfileCommand.Executed += OnFetchProfileCompleted;
        }

        public ProfileModel Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (this.model == value) return;
                this.model = value;
                RaisePropertyChanged();
            }
        }

        public override void Load(int id)
        {
            if (this.fetchProfileCommand.CanExecute(id))
            {
                this.fetchProfileCommand.Execute(id);
            }
        }

        private void OnExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnFetchProfileCompleted(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;

            if (e.State == CommandExecutionState.Success)
            {
                Model = this.fetchProfileCommand.Result;
                IsLoaded = true;
            }
        }
    }
}
