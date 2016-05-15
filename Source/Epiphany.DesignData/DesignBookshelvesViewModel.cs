using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookshelvesViewModel : DesignBaseViewModel, IBookshelvesViewModel
    {
        private Random random = new Random();
        public DesignBookshelvesViewModel()
        {
            IsLoading = true;
            IsLoaded = true;

            Name = Path.GetRandomFileName();
            Title = $"{Name}'s Bookshelves";

            PopulateBookshelves();
        }

        public IList<IBookItemViewModel> CurrentlyReadingList
        {
            get;
            set;
        }

        public bool IsBookshelvesLoading
        {
            get;
            set;
        }

        public bool IsCurrentlyReadingListLoading
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public IList<IBookshelfItemViewModel> Shelves
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        private void PopulateBookshelves()
        {
            Shelves = new ObservableCollection<IBookshelfItemViewModel>();

            for (int i = 1; i <= 5; i++)
            {
                Shelves.Add(new DesignBookshelfItemViewModel()
                {
                    Name = Path.GetRandomFileName().Replace(".", string.Empty),
                    NumberOfBooks = random.Next(0, 20)
                });
            }

            CurrentlyReadingList = new ObservableCollection<IBookItemViewModel>();

            for (int i = 1; i <= 5; i++)
            {
                CurrentlyReadingList.Add(new DesignBookItemViewModel()
                {
                    Title = Path.GetRandomFileName().Replace(".", string.Empty),
                    MainAuthor = new DesignAuthorItemViewModel()
                    {
                        Name = "Jeffrey Archer"
                    },
                    AverageRating = random.NextDouble() * 5,
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg"
                });
            }
        }
    }
}
