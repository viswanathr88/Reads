using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Commands;
using System.Collections.ObjectModel;

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
            CustomShelves = new ObservableCollection<ICustomBookshelfItemViewModel>();

            for (int i = 0; i < 5; i++)
            {
                BookshelfModel model = new BookshelfModel(i + 1);
                model.Name = "Test shelf " + (i + 1);
                CustomShelves.Add(new CustomBookshelfItemViewModel(model, i % 2 == 0));
            }

        }

        public ICommand<AddToShelvesCommandArgs> AddToShelves
        {
            get;
        }

        public AddToShelvesCommandArgs AddToShelvesArgs
        {
            get;
        }

        public BookModel Book
        {
            get;
            set;
        }

        public ICommand<string> CreateShelf
        {
            get;
        }

        public ObservableCollection<ICustomBookshelfItemViewModel> CustomShelves
        {
            get;
            set;
        }

        public long Id
        {
            get;
            set;
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
            set;
        }
    }
}
