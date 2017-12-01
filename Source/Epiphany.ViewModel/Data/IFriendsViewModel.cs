using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IFriendsViewModel : IDataViewModel
    {
        string Name
        {
            get;
        }
        string Title
        {
            get;
        }
        ILazyObservableCollection<IUserItemViewModel> FriendList
        {
            get;
        }
        bool AreFriendsEmpty
        {
            get;
        }
    }
}