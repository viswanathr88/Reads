namespace Epiphany.ViewModel
{
    public interface IBookshelfItemViewModel
    {
        int ShelfId { get; set; }

        int UserId { get; set; }

        string Name { get; set; }

        int NumberOfBooks { get; set; }
    }
}
