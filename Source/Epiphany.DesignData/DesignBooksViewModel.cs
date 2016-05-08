using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epiphany.View.DesignData
{
    sealed class DesignBooksViewModel : DesignBaseViewModel, IBooksViewModel
    {
        public DesignBooksViewModel()
        {
            Books = new ObservableCollection<IBookItemViewModel>();
        }
        public IList<IBookItemViewModel> Books
        {
            get;
            set;
        }

        public string ShelfName
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }
    }
}
