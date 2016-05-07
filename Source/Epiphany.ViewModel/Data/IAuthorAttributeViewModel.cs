namespace Epiphany.ViewModel
{
    public interface IAuthorAttributeViewModel
    {
        bool IsEnabled { get; }
        AuthorAttribute Type { get; }
        string Value { get; }
    }
}