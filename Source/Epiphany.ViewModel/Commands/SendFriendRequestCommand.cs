using Epiphany.Model;
using Epiphany.Model.Services;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class SendFriendRequestCommand : AsyncCommand<ProfileModel>
    {
        private readonly IUserService userService;

        public SendFriendRequestCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public override bool CanExecute(ProfileModel param)
        {
            return !param.IsFriend;
        }

        protected async override Task RunAsync(ProfileModel param)
        {
            //await Task.Delay(3000);
            await this.userService.AddFriend(param);
        }
    }
}
