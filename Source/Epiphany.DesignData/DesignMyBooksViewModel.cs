using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.IO;

namespace Epiphany.View.DesignData
{
    public sealed class DesignMyBooksViewModel : DesignBaseViewModel, IMyBooksViewModel
    {
        private Random random = new Random();

        public DesignMyBooksViewModel()
        {
            CurrentlyReadingBooks = new List<IBookItemViewModel>();
            for (int i = 0; i < 4; i++)
            {
                DesignBookItemViewModel item = new DesignBookItemViewModel()
                {
                    Title = Path.GetRandomFileName(),
                };
                CurrentlyReadingBooks.Add(item);
            }

            ReadingChallengeBooks = new List<IBookItemViewModel>();
            for (int i = 0; i < 4; i++)
            {
                DesignBookItemViewModel item = new DesignBookItemViewModel()
                {
                    Title = Path.GetRandomFileName(),
                };
                ReadingChallengeBooks.Add(item);
            }
        }


        public IList<IBookItemViewModel> CurrentlyReadingBooks
        {
            get;
            set;
        }

        public bool IsCurrentlyReadingBooksLoading
        {
            get;
            set;
        }

        public bool IsOwnedBooksLoading
        {
            get;
            set;
        }

        public bool IsReadingChallengeBooksLoading
        {
            get;
            set;
        }

        public IList<IBookItemViewModel> OwnedBooks
        {
            get;
            set;
        }

        public IList<IBookItemViewModel> ReadingChallengeBooks
        {
            get;
            set;
        }
    }
}
