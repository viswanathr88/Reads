using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookshelvesViewModel : DesignBaseViewModel, IBookshelvesViewModel
    {

        public DesignBookshelvesViewModel()
        {
            Id = 50;
            Name = "Test User";
            IsLoading = true;
            IsLoaded = true;

            PopulateBookshelves();
        }

        private void PopulateBookshelves()
        {
            Bookshelves = new ObservableCollection<IBookshelfItemViewModel>();

            for (int i = 0; i < 6; i++)
            {
                Bookshelves.Add(new DesignBookshelfItemViewModel()
                {
                    Name = "Test Shelf " + i,
                    NumberOfBooks = i * 100
                });
            }

            SelectedBookshelf = Bookshelves[0];
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<IBookshelfItemViewModel> Bookshelves { get; set; }

        public IAsyncEnumerator<BookshelfModel> BookshelfEnumerator { get; set; }

        public IBookshelfItemViewModel SelectedBookshelf { get; set; }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchMyShelves
        {
            get { return null; }
        }

        public ICommand ShowAddShelf
        {
            get { return null; }
        }

        public ICommand GoHome
        {
            get { return null; }
        }
    }
}
