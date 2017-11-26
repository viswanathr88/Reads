
using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Epiphany.ViewModel
{
    public sealed class FriendsViewModel : DataViewModel<UserModel>, IFriendsViewModel
    {
        private string name;
        private string title;
        private bool areFriendsEmpty;
        private IList<IUserItemViewModel> friendsList;

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
            get { return this.name; }
            private set
            {
                SetProperty(ref this.name, value);
            }
        }

        public bool AreFriendsEmpty
        {
            get { return this.areFriendsEmpty; }
            private set
            {
                SetProperty(ref this.areFriendsEmpty, value);
            }
        }

        public IList<IUserItemViewModel> FriendList
        {
            get { return this.friendsList; }
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
            var collection = this.userService.GetFriends(user.Id);
            var friends = new ObservablePagedCollection<IUserItemViewModel, UserModel>(collection, (model) => new UserItemViewModel(model));
            friends.Loading += (sender, arg) => IsLoading = true;
            friends.Loaded += (sender, arg) =>
            {
                IsLoading = false;
                IsLoaded = true;
            };
            FriendList = friends;

            return Task.FromResult<bool>(true);
        }

        protected override void Reset()
        {
            base.Reset();

            Name = string.Empty;
            Title = string.Empty;
            FriendList = null;
        }
    }
}
