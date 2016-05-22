namespace Epiphany.ViewModel.Items
{
    public interface IAuthorItemViewModel : IItemViewModel
    {
        int Id { get; }
        string Name { get; }
        string ImageUrl { get; }
    }
}