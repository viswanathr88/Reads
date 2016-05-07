using Epiphany.Model.Services;

namespace Epiphany.ViewModel
{
    public interface ISettingsViewModel : IDataViewModel
    {
        bool EnableLogging { get; set; }
        bool EnableTransparentTile { get; set; }
        BookSearchType SearchType { get; set; }
        BookSortOrder SortOrder { get; set; }
        BookSortType SortType { get; set; }
        FeedUpdateFilter UpdateFilter { get; set; }
        FeedUpdateType UpdateType { get; set; }
        bool UseMyLocation { get; set; }
    }
}