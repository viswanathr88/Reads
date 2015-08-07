
using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public sealed class FriendsViewModel : DataViewModel, IFriendsViewModel
    {
        private int id;
        private string name;
        private bool areFriendsEmpty;
        private UserModel selectedUser;
        private IList<KeyedList<string, UserModel>> friendsList;

        private readonly ICommand goHomeCommand;
        private readonly INavigationService navService;
        private readonly IUserService userService;
        private readonly IResourceLoader resourceLoader;

        public FriendsViewModel(IUserService userService, INavigationService navService, IResourceLoader resourceLoader)
        {
            if (userService == null || navService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.navService = navService;
            this.resourceLoader = resourceLoader;

            this.goHomeCommand = new GoHomeCommand(navService);
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (this.id == value) return;
                this.id = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value) return;
                this.name = value;
                RaisePropertyChanged();
            }
        }

        public bool AreFriendsEmpty
        {
            get { return this.areFriendsEmpty; }
            private set
            {
                if (this.areFriendsEmpty == value) return;
                this.areFriendsEmpty = value;
                RaisePropertyChanged();
            }
        }

        public UserModel SelectedUser
        {
            get { return this.selectedUser; }
            set
            {
                if (this.selectedUser == value) return;
                this.selectedUser = value;

                this.navService.CreateFor<IProfileViewModel>()
                    .AddParam<int>((x) => x.Id, this.selectedUser.Id)
                    .AddParam<string>((x) => x.Name, this.selectedUser.Name)
                    .Navigate();

                this.selectedUser = null;

                RaisePropertyChanged();
            }
        }

        public ICommand GoHome
        {
            get { return this.goHomeCommand; }
        }

        public IList<KeyedList<string, UserModel>> FriendList
        {
            get { return this.friendsList; }
            private set
            {
                if (this.friendsList == value) return;
                this.friendsList = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync()
        {
            IsLoading = true;
            IList<UserModel> friends = new List<UserModel>();
            IAsyncEnumerator<UserModel> enumerator = this.userService.GetFriends(Id).GetEnumerator();
            while (await enumerator.MoveNext())
            {
                friends.Add(enumerator.Current);
            }
            AreFriendsEmpty = (friends.Count == 0);
            this.FriendList = new ObservableCollection<KeyedList<string, UserModel>>(new AlphabetKeyedList<UserModel>(friends, ((model) => model.Name), resourceLoader));
            
            IsLoading = false;
            IsLoaded = true;
        }
    }
}
