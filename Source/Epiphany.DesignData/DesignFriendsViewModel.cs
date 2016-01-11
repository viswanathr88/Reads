using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignFriendsViewModel : DataViewModel, IFriendsViewModel
    {
        public DesignFriendsViewModel()
        {
            IsLoading = true;
            Name = "Test User";

            FriendList = new ObservableCollection<KeyedList<string, UserModel>>();
            for (int i = 0; i < 5; i++)
            {
                UserModel model = new UserModel(i);
                char c = (char)('a' + i);
                model.Name = c.ToString();
                model.ImageUrl = @"http://style.anu.edu.au/_anu/4/images/placeholders/person.png";

                KeyedList<string, UserModel> list = new KeyedList<string, UserModel>(c.ToString());
                list.Add(model);

                FriendList.Add(list);
            }

            
        }
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool AreFriendsEmpty
        {
            get;
            private set;
        }

        public UserModel SelectedUser
        {
            get;
            set;
        }

        public ICommand GoHome
        {
            get { return null; }
        }

        public IList<KeyedList<string, UserModel>> FriendList
        {
            get;
            private set;
        }

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
