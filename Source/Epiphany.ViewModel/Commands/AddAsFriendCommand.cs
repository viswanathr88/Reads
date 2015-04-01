using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Commands;
using System.Threading.Tasks;

namespace Epiphany.Commands
{
    class AddAsFriendCommand : AsyncCommand<VoidType, ProfileModel>
    {
        private readonly IUserService users;

        public AddAsFriendCommand(IUserService users)
        {
            this.users = users;
        }

        public override bool CanExecute(ProfileModel param)
        {
            return !param.IsFriend;
        }

        protected async override Task<VoidType> ExecuteAsync(ProfileModel param)
        {
            await this.users.AddFriend(param);
            return VoidType.Empty;
        }
    }
}
