using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using Epiphany.ViewModel;
using System;
using System.Runtime.CompilerServices;

namespace Epiphany.Settings
{
    public sealed class AppSettings : IAppSettings
    {
        private readonly string enableTransparentTileKey = "EnableTransparentTile";
        private readonly string useMyLocationKey = "UseMyLocation";
        private static object syncRoot = new object();
        private static volatile AppSettings instance;
        private readonly ModelSettings modelSettings;
        private readonly ISettingStorage storage;
        
        // Default values
        private const bool enableTransparentTileDefault = false;
        private const bool useMyLocationDefault = false;

        private AppSettings()
        {
            this.storage = SettingsStore.Instance;
            this.modelSettings = new ModelSettings(this.storage);
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
                return this.storage.GetValueOrDefault<bool>(enableTransparentTileKey, enableTransparentTileDefault);
            }
            set
            {
                if (storage.AddOrUpdate(enableTransparentTileKey, value))
                {
                    RaiseSettingChanged();
                }
            }
        }


        public bool UseMyLocation
        {
            get
            {
                return storage.GetValueOrDefault<bool>(useMyLocationKey, useMyLocationDefault);
            }
            set
            {
                if (storage.AddOrUpdate(useMyLocationKey, value))
                {
                    RaiseSettingChanged();
                }
            }
        }

        public FeedUpdateType UpdateType
        {
            get
            {
                return this.modelSettings.UpdateType;
            }
            set
            {
                if (this.modelSettings.UpdateType != value)
                {
                    this.modelSettings.UpdateType = value;
                    RaiseSettingChanged();
                }
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return this.modelSettings.UpdateFilter;
            }
            set
            {
                if (this.modelSettings.UpdateFilter != value)
                {
                    this.modelSettings.UpdateFilter = value;
                    RaiseSettingChanged();
                }
            }
        }

        public bool EnableLogging
        {
            get
            {
                return this.modelSettings.EnableLogging;
            }
            set
            {
                if (this.modelSettings.EnableLogging != value)
                {
                    this.modelSettings.EnableLogging = value;
                    RaiseSettingChanged();
                }
            }
        }

        public BookSortType SortType
        {
            get
            {
                return this.modelSettings.SortType;
            }
            set
            {
                if (this.modelSettings.SortType != value)
                {
                    this.modelSettings.SortType = value;
                    RaiseSettingChanged();
                }
            }
        }

        public BookSortOrder SortOrder
        {
            get
            {
                return this.modelSettings.SortOrder;
            }
            set
            {
                if (this.modelSettings.SortOrder != value)
                {
                    this.modelSettings.SortOrder = value;
                    RaiseSettingChanged();
                }
            }
        }

        public BookSearchType SearchType
        {
            get
            {
                return this.modelSettings.SearchType;
            }
            set
            {
                if (this.modelSettings.SearchType != value)
                {
                    this.modelSettings.SearchType = value;
                    RaiseSettingChanged();
                }
            }
        }

        public event EventHandler<SettingsChangedEventArgs> SettingChanged;

        private void RaiseSettingChanged([CallerMemberName] string settingName = "")
        {
            if (SettingChanged != null && !string.IsNullOrEmpty(settingName))
            {
                SettingChanged(this, new SettingsChangedEventArgs(settingName));
            }
        }
    }
}
