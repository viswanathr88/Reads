using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IFriendsViewModel : IDataViewModel
    {
        string Name { get; }
        string Title { get; }
        IList<IUserItemViewModel> FriendList { get; }
        bool AreFriendsEmpty { get; }
    }
}