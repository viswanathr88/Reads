using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Epiphany.ViewModel.Commands;
using System.Windows.Input;

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

        public ICommand CancelCreateShelf
        {
            get;
            set;
        }

        public bool CanEdit
        {
            get;
            set;
        }

        public ICommand<string> CreateShelf
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string NewShelfName
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
        }
    }
}
