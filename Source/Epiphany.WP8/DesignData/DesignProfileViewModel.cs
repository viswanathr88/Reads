using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    public sealed class DesignProfileViewModel : DataViewModel, IProfileViewModel
    {
        public DesignProfileViewModel()
        {
            Id = 50;
            Name = "Test User";
            AreUpdatesEmpty = true;
            IsLoading = false;
            IsLoaded = true;
            //ImageUrl = "http://www.viscofoods.com/wp-content/themes/456market/assets/img/placeholder.png";

            ProfileItems = new List<ProfileItemViewModel>();
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.Age, "25", false));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.Username, "testuser", false));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.ViewInGoodreads, "www.goodreads.com", true));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.JoinDate, DateTime.Now.ToShortDateString(), false));

            Shelves = new ObservableCollection<BookshelfModel>();

            for (int i = 0; i < 5; i++)
            {
                BookshelfModel shelf = new BookshelfModel(i)
                {
                    Name = "Test Shelf",
                    BooksCount = 50
                };
                Shelves.Add(shelf);
            }
            ShelvesLoaded = true;
            AreShelvesEmpty = false;
        }
        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public ProfileModel Model
        {
            get;
            private set;
        }

        public bool AreShelvesEmpty
        {
            get;
            private set;
        }

        public bool AreUpdatesEmpty
        {
            get;
            private set;
        }

        public string ImageUrl
        {
            get;
            private set;
        }

        public System.Windows.Input.ICommand GoHome
        {
            get { return null; }
        }

        public IAsyncCommand<Model.ProfileModel, int> FetchProfile
        {
            get { return null; }
        }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get { return null; }
        }

        public IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get { return null; }
        }

        public override Task LoadAsync()
        {
            throw new NotImplementedException();
        }


        public IList<ProfileItemViewModel> ProfileItems
        {
            get;
            private set;
        }


        public bool ShelvesLoaded
        {
            get;
            set;
        }

        public IList<BookshelfModel> Shelves
        {
            get;
            set;
        }


        public BookshelfModel SelectedShelf
        {
            get { return null; }
        }
    }
}
