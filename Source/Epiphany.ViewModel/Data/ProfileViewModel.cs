using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class ProfileViewModel : DataViewModel, IProfileViewModel
    {
        private int id;
        private string name;
        private string imageUrl;
        private ProfileModel profileModel;
        private readonly ProfileItemViewModelFactory profileItemFactory;

        private readonly IBookshelfService bookshelfService;
        private readonly INavigationService navService;
        private readonly IUrlLauncher urlLauncher;

        private readonly IAsyncCommand<ProfileModel, int> fetchProfileCommand;
        private readonly IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> fetchBookshelvesCommand;
        private IAsyncEnumerator<BookshelfModel> enumerator;
        private readonly ICommand goHomeCommand;
        private bool areShelvesEmpty;
        private bool areUpdatesEmpty;
        private bool shelvesLoaded;

        private IList<BookshelfModel> shelves;
        private IList<ProfileItemViewModel> profileItems;
        private BookshelfModel selectedShelf;
        private ProfileItemViewModel selectedProfileItem;

        public ProfileViewModel(IUserService userService, IBookshelfService bookshelfService, INavigationService navService, IUrlLauncher urlLauncher)
        {
            if (userService == null || navService == null || bookshelfService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.bookshelfService = bookshelfService;
            this.navService = navService;
            this.urlLauncher = urlLauncher;
            this.profileItemFactory = new ProfileItemViewModelFactory();

            this.fetchProfileCommand = new FetchProfileCommand(userService);
            this.fetchProfileCommand.Executing += OnCommandExecuting;
            this.fetchProfileCommand.Executed += OnProfileFetched;

            this.fetchBookshelvesCommand = new FetchBookshelvesCommand(bookshelfService);
            this.fetchBookshelvesCommand.Executing += OnCommandExecuting;
            this.fetchBookshelvesCommand.Executed += OnBookshelvesFetched;

            this.goHomeCommand = new GoHomeCommand(navService);

            Shelves = new ObservableCollection<BookshelfModel>();
            ProfileItems = new ObservableCollection<ProfileItemViewModel>();
        }

        public int Id
        {
            get { return this.id;  }
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

        public ProfileModel Model
        {
            get { return this.profileModel; }
            private set
            {
                if (this.profileModel == value) return;
                this.profileModel = value;
                RaisePropertyChanged();
            }
        }

        public bool AreShelvesEmpty
        {
            get { return this.areShelvesEmpty; }
            private set
            {
                if (this.areShelvesEmpty == value) return;
                this.areShelvesEmpty = value;
                RaisePropertyChanged();
            }
        }

        public bool AreUpdatesEmpty
        {
            get
            {
                return this.areUpdatesEmpty;
            }
            private set
            {
                if (this.areUpdatesEmpty == value) return;
                this.areUpdatesEmpty = value;
                RaisePropertyChanged();
            }
        }

        public bool ShelvesLoaded
        {
            get { return this.shelvesLoaded; }
            private set
            {
                if (this.shelvesLoaded == value) return;
                this.shelvesLoaded = value;
                RaisePropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            private set
            {
                if (this.imageUrl == value) return;
                this.imageUrl = value;
                RaisePropertyChanged();
            }
        }

        public IList<BookshelfModel> Shelves
        {
            get { return this.shelves; }
            private set
            {
                if (this.shelves == value) return;
                this.shelves = value;
                RaisePropertyChanged();
            }
        }

        public BookshelfModel SelectedShelf
        {
            get { return this.selectedShelf; }
            set
            {
                if (this.selectedShelf == value) return;
                this.selectedShelf = value;

                this.navService.CreateFor<IBooksViewModel>()
                    .AddParam<int>((x) => x.UserId, Id)
                    .AddParam<string>((x) => x.UserName, Name)
                    .AddParam<string>((x) => x.ShelfName, this.selectedShelf.Name)
                    .Navigate();

                this.selectedShelf = null;
                RaisePropertyChanged();
            }
        }

        public ProfileItemViewModel SelectedProfileItem
        {
            get { return this.selectedProfileItem; }
            set
            {
                if (this.selectedProfileItem == value) return;
                this.selectedProfileItem = value;

                switch (this.selectedProfileItem.Type)
                {
                    case ProfileItemType.Friends:
                        {
                            this.navService.CreateFor<IFriendsViewModel>()
                                .AddParam<int>((x) => x.Id, Id)
                                .AddParam<string>((x) => x.Name, Name)
                                .Navigate();
                            break;
                        }

                    case ProfileItemType.Groups:
                        {
                            this.navService.CreateFor<IGroupsViewModel>()
                                .AddParam<int>((x) => x.Id, Id)
                                .AddParam<string>((x) => x.Name, Name)
                                .Navigate();
                            break;
                        }

                    case ProfileItemType.ViewInGoodreads:
                        {
                            this.urlLauncher.Launch(this.selectedProfileItem.Value);
                            break;
                        }
                    default:
                        break;
                }
                this.selectedProfileItem = null;
                RaisePropertyChanged(() => SelectedProfileItem);
            }
        }

        public IList<ProfileItemViewModel> ProfileItems
        {
            get { return this.profileItems; }
            set
            {
                if (this.profileItems == value) return;
                this.profileItems = value;
                RaisePropertyChanged();
            }
        }

        public ICommand GoHome
        {
            get { return this.goHomeCommand; }
        }

        public IAsyncCommand<ProfileModel, int> FetchProfile
        {
            get { return this.fetchProfileCommand; }
        }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get { return this.fetchBookshelvesCommand; }
        }

        public IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get { return this.enumerator; }
            private set
            {
                if (this.enumerator == value) return;
                this.enumerator = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync()
        {
            if (!IsLoaded && this.fetchProfileCommand.CanExecute(Id))
            {
                await this.fetchProfileCommand.ExecuteAsync(Id);
            }
        }

        private void OnCommandExecuting(object sender, CancelEventArgs e)
        {
            IsLoading = true;
        }

        private void OnProfileFetched(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                Model = this.fetchProfileCommand.Result;
                ImageUrl = Model.ImageUrl;
                FetchBookshelvesArg = this.bookshelfService.GetBookshelves(Id).GetEnumerator();
                ProfileItems = this.profileItemFactory.GetProfileItems(Model);
                IsLoaded = true;
            }
        }
        private void OnBookshelvesFetched(object sender, ExecutedEventArgs e)
        {
            IsLoading = false;
            if (e.State == CommandExecutionState.Success)
            {
                foreach (BookshelfModel shelf in this.fetchBookshelvesCommand.Result)
                {
                    Shelves.Add(shelf);
                }
                AreShelvesEmpty = (Shelves.Count == 0);
                ShelvesLoaded = true;
            }
        }
    }
}
