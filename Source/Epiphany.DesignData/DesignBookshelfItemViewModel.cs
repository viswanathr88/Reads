using Epiphany.ViewModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookshelfItemViewModel : ViewModelBase, IBookshelfItemViewModel
    {
        public int ShelfId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int NumberOfBooks { get; set; }
    }
}
