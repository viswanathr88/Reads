namespace Epiphany.ViewModel.Items
{
    public interface IUserItemViewModel : IItemViewModel
    {
        int Id { get; }
        string ImageUrl { get; }
        string Name { get; }
    }
}