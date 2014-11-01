using Epiphany.Model.Services;
using System.ComponentModel;

namespace Epiphany.Settings
{
    public sealed class AppSettings : IAppSettings
    {
        //
        // Private members
        //
        private static object syncRoot = new object();
        private static volatile AppSettings instance;
        private readonly ISettingStorage storage;
        //
        // Default values
        //
        private const bool enableTransparentTileDefault = false;
        private const bool useMyLocationDefault = false;
        private const FeedUpdateType updateTypeDefault = FeedUpdateType.all;
        private const FeedUpdateFilter updateFilterDefault = FeedUpdateFilter.friends;
        private const bool enableLoggingDefault = false;
        private const BookSortType sortTypeDefault = BookSortType.date_added;
        private const BookSortOrder sortOrderDefault = BookSortOrder.d;
        private const BookSearchType searchTypeDefault = BookSearchType.All;

        private AppSettings()
        {
            this.storage = SettingsStore.Instance;
        }
        
        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new AppSettings();
                    }
                }

                return instance;
            }
        }
        public bool EnableTransparentTile
        {
            get
            {
                return this.storage.GetValueOrDefault<bool>(SettingKeys.EnableTransparentTile, enableTransparentTileDefault);
            }
            set
            {
                if (storage.AddOrUpdate(SettingKeys.EnableTransparentTile, value))
                {
                    RaisePropertyChanged(SettingKeys.EnableTransparentTile);
                }
            }
        }


        public bool UseMyLocation
        {
            get
            {
                return storage.GetValueOrDefault<bool>(SettingKeys.UseMyLocation, useMyLocationDefault);
            }
            set
            {
                if (storage.AddOrUpdate(SettingKeys.UseMyLocation, value))
                {
                    RaisePropertyChanged(SettingKeys.UseMyLocation);
                }
            }
        }

        public FeedUpdateType UpdateType
        {
            get
            {
                return storage.GetValueOrDefault<FeedUpdateType>(SettingKeys.UpdateTypeKey, updateTypeDefault);
            }
            set
            {
                if (storage.AddOrUpdate(SettingKeys.UpdateTypeKey, value))
                {
                    RaisePropertyChanged(SettingKeys.UpdateTypeKey);
                }
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return storage.GetValueOrDefault<FeedUpdateFilter>(SettingKeys.UpdateFilterKey, updateFilterDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.UpdateFilterKey, value);
            }
        }

        public bool EnableLogging
        {
            get
            {
                return storage.GetValueOrDefault<bool>(SettingKeys.EnableLoggingKey, enableLoggingDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.EnableLoggingKey, value);
            }
        }

        public BookSortType SortType
        {
            get
            {
                return storage.GetValueOrDefault<BookSortType>(SettingKeys.SortTypeKey, sortTypeDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SortTypeKey, value);
            }
        }

        public BookSortOrder SortOrder
        {
            get
            {
                return storage.GetValueOrDefault<BookSortOrder>(SettingKeys.SortOrderKey, sortOrderDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SortOrderKey, value);
            }
        }

        public BookSearchType SearchType
        {
            get
            {
                return storage.GetValueOrDefault<BookSearchType>(SettingKeys.SearchTypeKey, searchTypeDefault);
            }
            set
            {
                storage.AddOrUpdate(SettingKeys.SearchTypeKey, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
