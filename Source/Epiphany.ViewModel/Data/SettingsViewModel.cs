using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class SettingsViewModel : DataViewModel<VoidType>
    {
        public FeedUpdateType UpdateType
        {
            get
            {
                return ApplicationSettings.Instance.UpdateType;
            }
            set
            {
                if (ApplicationSettings.Instance.UpdateType != value)
                {
                    ApplicationSettings.Instance.UpdateType = value;
                    RaisePropertyChanged();
                }
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return ApplicationSettings.Instance.UpdateFilter;
            }
            set
            {
                if (ApplicationSettings.Instance.UpdateFilter != value)
                {
                    ApplicationSettings.Instance.UpdateFilter = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EnableLogging
        {
            get
            {
                return ApplicationSettings.Instance.EnableLogging;
            }
            set
            {
                if (ApplicationSettings.Instance.EnableLogging != value)
                {
                    ApplicationSettings.Instance.EnableLogging = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool UseMyLocation
        {
            get
            {
                return ApplicationSettings.Instance.UseMyLocation;
            }
            set
            {
                if (ApplicationSettings.Instance.UseMyLocation != value)
                {
                    ApplicationSettings.Instance.UseMyLocation = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BookSortType SortType
        {
            get
            {
                return ApplicationSettings.Instance.SortType;
            }
            set
            {
                if (ApplicationSettings.Instance.SortType != value)
                {
                    ApplicationSettings.Instance.SortType = value;
                    RaisePropertyChanged();
                }
            }
        }

        public BookSortOrder SortOrder
        {
            get
            {
                return ApplicationSettings.Instance.SortOrder;
            }
            set
            {
                if (ApplicationSettings.Instance.SortOrder != value)
                {
                    ApplicationSettings.Instance.SortOrder = value;
                    RaisePropertyChanged();
                }
                
            }
        }

        public BookSearchType SearchType
        {
            get
            {
                return ApplicationSettings.Instance.SearchType;
            }
            set
            {
                if (ApplicationSettings.Instance.SearchType != value)
                {
                    ApplicationSettings.Instance.SearchType = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EnableTransparentTile
        {
            get
            {
                return ApplicationSettings.Instance.EnableTransparentTile;
            }
            set
            {
                if (ApplicationSettings.Instance.EnableTransparentTile != value)
                {
                    ApplicationSettings.Instance.EnableTransparentTile = value;
                    RaisePropertyChanged();
                }
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
