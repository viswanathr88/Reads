namespace Epiphany.ViewModel.Items
{
    public interface IBookshelfItemViewModel
    {
        int ShelfId { get; }

        string Name { get; }

        int NumberOfBooks { get; }
    }
}
