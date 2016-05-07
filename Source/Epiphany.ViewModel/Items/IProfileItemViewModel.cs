namespace Epiphany.ViewModel.Items
{
    public interface IProfileItemViewModel
    {
        bool IsEnabled { get; }
        ProfileItemType Type { get; }
        string Value { get; }
    }
}