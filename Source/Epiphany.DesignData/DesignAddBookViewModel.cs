using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAddBookViewModel : DesignBaseViewModel, IAddBookViewModel
    {
        public DesignAddBookViewModel()
        {
            Id = 50;
            Title = "Test Book";
            IsCurrentlyReadingSelected = true;

            PopulateCustomShelves();
        }

        private void PopulateCustomShelves()
        {
            CustomShelves = new ObservableCollection<CustomBookshelfItemViewModel>();

            for (int i = 0; i < 5; i++)
            {
                BookshelfModel model = new BookshelfModel(i + 1);
                model.Name = "Test shelf " + (i + 1);
                CustomShelves.Add(new CustomBookshelfItemViewModel(model, i % 2 == 0));
            }

        }

        public ICommand<ViewModel.Commands.AddToShelvesCommandArgs> AddToShelves
        {
            get { throw new NotImplementedException(); }
        }

        public AddToShelvesCommandArgs AddToShelvesArgs
        {
            get { throw new NotImplementedException(); }
        }

        public BookModel Book
        {
            get { throw new NotImplementedException(); }
        }

        public ViewModel.Commands.ICommand<string> CreateShelf
        {
            get { throw new NotImplementedException(); }
        }

        public ObservableCollection<CustomBookshelfItemViewModel> CustomShelves
        {
            get;
            private set;
        }

        public int Id
        {
            get;
            private set;
        }

        public bool IsCurrentlyReadingSelected
        {
            get;
            set;
        }

        public bool IsReadSelected
        {
            get;
            set;
        }

        public bool IsToReadSelected
        {
            get;
            set;
        }

        public string ShelfName
        {
            get;
            set;
        }

        public string Title
        {
            get;
            private set;
        }
    }
}
