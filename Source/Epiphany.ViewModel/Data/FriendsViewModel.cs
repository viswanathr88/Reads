
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
namespace Epiphany.ViewModel
{
    public sealed class FriendsViewModel : DataViewModel<UserModel>, IFriendsViewModel
    {
        private string name;
        private string title;
        private bool areFriendsEmpty;
        private ILazyObservableCollection<IUserItemViewModel> friendsList;

        private readonly IUserService userService;
        private readonly IResourceLoader resourceLoader;

        private const string titleFormatKey = "UserFriendsTitleFormat";

        public FriendsViewModel(IUserService userService, IResourceLoader resourceLoader)
        {
            if (userService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.userService = userService;
            this.resourceLoader = resourceLoader;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                SetProperty(ref this.name, value);
            }
        }

        public bool AreFriendsEmpty
        {
            get
            {
                return this.areFriendsEmpty;
            }
            private set
            {
                SetProperty(ref this.areFriendsEmpty, value);
            }
        }

        public ILazyObservableCollection<IUserItemViewModel> FriendList
        {
            get
            {
                return this.friendsList;
            }
            private set
            {
                SetProperty(ref this.friendsList, value);
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                SetProperty(ref this.title, value);
            }
        }

        public override Task LoadAsync(UserModel user)
        {
            Name = user.Name;
            Title = string.Format(this.resourceLoader.GetString(titleFormatKey), Name);
            FriendList = new LazyObservablePagedCollection<IUserItemViewModel, UserModel>
                (this.userService.GetFriends(user.Id), (model) => new UserItemViewModel(model));
            FriendList.PropertyChanged += FriendList_PropertyChanged;

            return Task.FromResult<bool>(true);
        }

        private void FriendList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FriendList.IsLoading))
            {
                IsLoading = FriendList.IsLoading;
                if (!FriendList.IsLoading)
                {
                    IsLoaded = (FriendList.Count != 0 || Error != null);
                }

            }
            else if (e.PropertyName == nameof(FriendList.Error))
            {
                Error = FriendList.Error;
                IsLoaded = false;
            }
        }

        protected override void Reset()
        {
            base.Reset();

            Name = string.Empty;
            Title = string.Empty;
            FriendList = null;
        }

        public override void Dispose()
        {
            base.Dispose();

            if (FriendList != null)
            {
                FriendList.PropertyChanged -= FriendList_PropertyChanged;
            }
        }
    }
}
