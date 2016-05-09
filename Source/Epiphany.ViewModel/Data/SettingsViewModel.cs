using Epiphany.Model.Services;
using Epiphany.Model.Settings;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class SettingsViewModel : DataViewModel<VoidType>, ISettingsViewModel
    {
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
