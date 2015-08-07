using Epiphany.Model;
using Epiphany.Model.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class FetchFriendsCommand : AsyncCommand<IEnumerable<UserModel>, IAsyncEnumerator<UserModel>>
    {
        public override bool CanExecute(IAsyncEnumerator<UserModel> enumerator)
        {
            return true;
        }

        protected override async Task RunAsync(IAsyncEnumerator<UserModel> enumerator)
        {
            IList<UserModel> users = new List<UserModel>();
            while (await enumerator.MoveNext())
            {
                users.Add(enumerator.Current);
            }

            Result = users;
        }
    }
}
