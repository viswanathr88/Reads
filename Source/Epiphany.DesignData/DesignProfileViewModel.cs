﻿using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignProfileViewModel : DesignBaseViewModel, IProfileViewModel
    {
        public DesignProfileViewModel()
        {
            Id = 50;
            Name = "Test User";
            Username = "viswanathr";
            MemberSinceString = "Jan 2010";
            Location = "Chennai, 20, India";
            AreUpdatesEmpty = true;
            IsLoading = false;
            IsLoaded = true;
            FriendsCount = 25;
            GroupsCount = 50;
            ReviewsCount = 75;
            ImageUrl = "http://www.viscofoods.com/wp-content/themes/456market/assets/img/placeholder.png";

            ProfileItems = new List<IProfileItemViewModel>();
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.Age, "25", false));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.Username, "testuser", false));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.ViewInGoodreads, "www.goodreads.com", true));
            ProfileItems.Add(new ProfileItemViewModel(ProfileItemType.JoinDate, DateTime.Now.ToString(), false));

            FavoriteAuthors = new List<IAuthorItemViewModel>();
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 50,
                Name = "Jeffrey Archer"
            });
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 51,
                Name = "Sidney Sheldon"
            });
            FavoriteAuthors.Add(new DesignAuthorItemViewModel()
            {
                Id = 52,
                Name = "George R. R. Martin"
            });

            SelectedProfileItem = ProfileItems[0];

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
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ProfileModel Model
        {
            get;
            set;
        }

        public bool AreShelvesEmpty
        {
            get;
            set;
        }

        public bool AreUpdatesEmpty
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public System.Windows.Input.ICommand GoHome
        {
            get;
        }

        public IAsyncCommand<Model.ProfileModel, int> FetchProfile
        {
            get;
        }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get;
        }

        public IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get;
        }

        public IList<IProfileItemViewModel> ProfileItems
        {
            get;
            set;
        }

        public IList<IFeedItemViewModel> RecentUpdates
        {
            get;
            set;
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

        public IProfileItemViewModel SelectedProfileItem
        {
            get;
            set;
        }


        public BookshelfModel SelectedShelf
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string MemberSinceString
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public int FriendsCount
        {
            get;
            set;
        }

        public int GroupsCount
        {
            get;
            set;
        }

        public int ReviewsCount
        {
            get;
            set;
        }

        public IList<IAuthorItemViewModel> FavoriteAuthors
        {
            get;
            set;
        }
    }
}
