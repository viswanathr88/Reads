using Epiphany.Model;
using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class FetchProfileCommand : AsyncCommand<ProfileModel, int>
    {
        private readonly IUserService userService;

        public FetchProfileCommand(IUserService userService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("navService");
            }

            this.userService = userService;
        }
        public override bool CanExecute(int param)
        {
            return true;
        }

        protected async override Task RunAsync(int param)
        {
            Result = await this.userService.GetProfile(param);
        }
    }
}
