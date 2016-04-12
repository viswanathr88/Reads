using Epiphany.Model.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class SettingsViewModel : DataViewModel<VoidType>, ISettingsViewModel
    {
        private readonly IAppSettings settings;

        public SettingsViewModel(IAppSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            //
            // Nothing to do here
            //
            IsLoaded = true;
            await Task.FromResult(true);
        }
    }
}
