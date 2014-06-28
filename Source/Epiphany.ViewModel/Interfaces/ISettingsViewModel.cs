using Epiphany.Model.Services;
using System;
using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface ISettingsViewModel : INotifyPropertyChanged, IDisposable
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

        bool UseMyLocation
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
    }
}
