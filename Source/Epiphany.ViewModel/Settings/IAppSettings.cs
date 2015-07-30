using Epiphany.Model.Services;
using System;

namespace Epiphany.ViewModel
{
    public interface IAppSettings
    {
        FeedUpdateType UpdateType
        {
            get;
            set;
        }

        FeedUpdateFilter UpdateFilter
        {
            get;
            set;
        }

        bool EnableLogging
        {
            get;
            set;
        }

        BookSortType SortType
        {
            get;
            set;
        }

        BookSortOrder SortOrder
        {
            get;
            set;
        }

        BookSearchType SearchType
        {
            get;
            set;
        }

        bool EnableTransparentTile
        {
            get;
            set;
        }

        bool UseMyLocation
        {
            get;
            set;
        }

        event EventHandler<SettingsChangedEventArgs> SettingChanged;
    }
}
