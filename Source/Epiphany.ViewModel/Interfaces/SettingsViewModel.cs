using Epiphany.Model.Services;
using System;

namespace Epiphany.ViewModel
{
    public sealed class SettingsViewModel : DataViewModel, ISettingsViewModel
    {
        private readonly IAppSettings settings;

        public SettingsViewModel(IAppSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException();
            }

            this.settings = settings;
        }

        public FeedUpdateType UpdateType
        {
            get
            {
                return this.settings.UpdateType;
            }
            set
            {
                this.settings.UpdateType = value;
                RaisePropertyChanged(() => UpdateType);
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return this.settings.UpdateFilter;
            }
            set
            {
                this.settings.UpdateFilter = value;
                RaisePropertyChanged(() => UpdateFilter);
            }
        }

        public bool EnableLogging
        {
            get
            {
                return this.settings.EnableLogging;
            }
            set
            {
                this.settings.EnableLogging = value;
                RaisePropertyChanged(() => EnableLogging);
            }
        }

        public bool UseMyLocation
        {
            get
            {
                return this.settings.UseMyLocation;
            }
            set
            {
                this.settings.UseMyLocation = value;
                RaisePropertyChanged(() => UseMyLocation);
            }
        }

        public BookSortType SortType
        {
            get
            {
                return this.settings.SortType;
            }
            set
            {
                this.settings.SortType = value;
                RaisePropertyChanged(() => SortType);
            }
        }

        public BookSortOrder SortOrder
        {
            get
            {
                return this.settings.SortOrder;
            }
            set
            {
                this.settings.SortOrder = value;
            }
        }

        public BookSearchType SearchType
        {
            get
            {
                return this.settings.SearchType;
            }
            set
            {
                this.settings.SearchType = value;
                RaisePropertyChanged(() => SortOrder);
            }
        }

        public bool EnableTransparentTile
        {
            get
            {
                return this.settings.EnableTransparentTile;
            }
            set
            {
                this.settings.EnableTransparentTile = value;
                RaisePropertyChanged(() => EnableTransparentTile);
            }
        }

        public override void Load()
        {
            //
            // Nothing to do here
            //
            IsLoaded = true;
        }
    }
}
