using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookshelfItemViewModel : DesignBaseItemViewModel, IBookshelfItemViewModel
    {
        public long ShelfId
        {
            get;
            set;
        }

        public long UserId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int NumberOfBooks
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
