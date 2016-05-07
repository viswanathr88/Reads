using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.ViewModel.Collections;

namespace Epiphany.ViewModel
{
    public interface IFriendsViewModel : IDataViewModel
    {
        bool AreFriendsEmpty { get; }
        IList<KeyedList<string, UserModel>> FriendList { get; }
        ICommand GoHome { get; }
        int Id { get; set; }
        string Name { get; set; }
        UserModel SelectedUser { get; set; }
    }
}