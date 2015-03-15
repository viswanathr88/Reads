using Epiphany.Model.Services;
using System;
using System.ComponentModel;

namespace Epiphany.Settings
{
    public enum Theme
    {
        Default,
        ReadsTheme,
        EpiphanyTheme
    };

    public interface IAppSettings : INotifyPropertyChanged
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

        Theme CurrentTheme
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
    }
}
