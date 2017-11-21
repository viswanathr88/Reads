namespace Epiphany.ViewModel.Items
{
    public interface IAuthorItemViewModel : IItemViewModel
    {
        long Id {get; }
        string Name { get; }
        string ImageUrl { get; }
    }
}