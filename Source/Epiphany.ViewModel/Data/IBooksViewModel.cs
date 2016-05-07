namespace Epiphany.ViewModel
{
    public interface IBooksViewModel : IDataViewModel
    {
        string ShelfName { get; set; }
        int UserId { get; set; }
        string UserName { get; set; }
    }
}