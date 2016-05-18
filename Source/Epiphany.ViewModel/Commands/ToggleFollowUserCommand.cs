using Epiphany.Model;
using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class ToggleFollowUserCommand : AsyncCommand<ProfileModel>
    {
        private readonly IUserService userService;

        public ToggleFollowUserCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override bool CanExecute(ProfileModel user)
        {
            return true;
        }

        protected async override Task RunAsync(ProfileModel user)
        {
            if (user.IsFollowing)
            {
                await this.userService.UnfollowUser(user);
            }
            else
            {
                await this.userService.FollowUser(user);
            }
        }
    }
}
