namespace Epiphany.ViewModel.Items
{
    public interface IUserItemViewModel : IItemViewModel
    {
        long Id {get; }
        string ImageUrl { get; }
        string Name { get; }
    }
}