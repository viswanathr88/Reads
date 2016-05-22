namespace Epiphany.ViewModel.Items
{
    public interface IBookshelfItemViewModel : IItemViewModel
    {
        int ShelfId { get; }

        string Name { get; }

        IUserItemViewModel User { get; }

        int NumberOfBooks { get; }
    }
}
