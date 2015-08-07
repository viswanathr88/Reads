
using Epiphany.Model;
using Epiphany.ViewModel.Collections;
using System.Collections.Generic;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IFriendsViewModel : IDataViewModel
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        bool AreFriendsEmpty
        {
            get;
        }

        UserModel SelectedUser
        {
            get;
            set;
        }

        ICommand GoHome
        {
            get;
        }

        IList<KeyedList<string, UserModel>> FriendList
        {
            get;
        }
    }
}
