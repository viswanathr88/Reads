﻿using Epiphany.Model.Services;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epiphany.View.DesignData
{
    sealed class DesignBooksViewModel : DesignBaseViewModel, IBooksViewModel
    {
        public DesignBooksViewModel()
        {
            ShelfName = "to-read";
            User = new DesignUserItemViewModel()
            {
                Name = "Test User"
            };

            Books = new DesignLazyObservableCollection<IBookItemViewModel>();

            Filters = Enum.GetValues(typeof(BookSortType)).Cast<BookSortType>().ToList();
            SelectedFilter = BookSortType.date_added;

            for (int i = 0; i < 5; i++)
            {
                Books.Add(new DesignBookItemViewModel()
                {
                    Id = i,
                    Title = "Test Book " + i,
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg",
                    AverageRating = 4.0,
                    RatingsCount = 554,
                    MainAuthor = new DesignAuthorItemViewModel()
                    {
                        Name = "Test Author"
                    }
                });
            }

            SelectedFilter = BookSortType.num_ratings;
            SelectedOrderByFilter = BookSortOrder.d;
        }

        public ILazyObservableCollection<IBookItemViewModel> Books
        {
            get;
            set;
        }

        public IList<BookSortType> Filters
        {
            get;
            set;
        }

        public IList<BookSortOrder> OrderByFilters
        {
            get;
            set;
        }

        public BookSortType SelectedFilter
        {
            get;
            set;
        }

        public BookSortOrder SelectedOrderByFilter
        {
            get;
            set;
        }

        public string ShelfName
        {
            get;
            set;
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }
    }
}
