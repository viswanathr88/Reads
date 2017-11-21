namespace Epiphany.ViewModel.Items
{
    public interface IBookshelfItemViewModel : IItemViewModel
    {
        long ShelfId { get; }

        string Name { get; }

        IUserItemViewModel User { get; }

        int NumberOfBooks { get; }
    }
}
