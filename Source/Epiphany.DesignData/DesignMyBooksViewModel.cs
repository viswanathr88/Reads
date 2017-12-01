using Epiphany.ViewModel;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System;
using System.IO;

namespace Epiphany.View.DesignData
{
    public sealed class DesignMyBooksViewModel : DesignBaseViewModel, IMyBooksViewModel
    {
        private Random random = new Random();

        public DesignMyBooksViewModel()
        {
            CurrentlyReadingBooks = new DesignLazyObservableCollection<IBookItemViewModel>();
            for (int i = 0; i < 4; i++)
            {
                DesignBookItemViewModel item = new DesignBookItemViewModel()
                {
                    Title = Path.GetRandomFileName(),
                };
                CurrentlyReadingBooks.Add(item);
            }

            ReadingChallengeBooks = new DesignLazyObservableCollection<IBookItemViewModel>();
            for (int i = 0; i < 4; i++)
            {
                DesignBookItemViewModel item = new DesignBookItemViewModel()
                {
                    Title = Path.GetRandomFileName(),
                };
                ReadingChallengeBooks.Add(item);
            }
        }


        public ILazyObservableCollection<IBookItemViewModel> CurrentlyReadingBooks
        {
            get;
            set;
        }

        public ILazyObservableCollection<IBookItemViewModel> OwnedBooks
        {
            get;
            set;
        }

        public ILazyObservableCollection<IBookItemViewModel> ReadingChallengeBooks
        {
            get;
            set;
        }
    }
}
