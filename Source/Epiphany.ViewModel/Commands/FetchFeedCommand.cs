using Epiphany.Model;
using Epiphany.Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    class FetchFeedCommand : AsyncCommand<IEnumerable<FeedItemModel>, VoidType>
    {
        private readonly IUserService userService;

        public FetchFeedCommand(IUserService userService)
        {
            this.userService = userService;
        }
        public override bool CanExecute(VoidType param)
        {
            return true;
        }

        protected override async Task<IEnumerable<FeedItemModel>> ExecuteAsync(VoidType param)
        {
            return await this.userService.GetFriendUpdatesAsync(FeedUpdateType.all, FeedUpdateFilter.friends);
        }
    }
}
