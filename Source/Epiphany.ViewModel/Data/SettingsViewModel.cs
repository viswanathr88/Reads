using Epiphany.Model.Settings;
using System.Threading.Tasks;
using System;
using System.Windows.Input;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel
{
    public sealed class SettingsViewModel : DataViewModel<VoidType>, ISettingsViewModel
    {
        private readonly IDeviceServices deviceServices;

        public SettingsViewModel(IDeviceServices deviceServices)
        {
            if (deviceServices == null)
            {
                throw new ArgumentNullException(nameof(deviceServices));
            }

            this.deviceServices = deviceServices;
            LikeOnFacebook = new DelegateCommand(async () => await this.deviceServices.LaunchUrl(@"https://www.facebook.com/epiphanywp"));
            RateApp = new DelegateCommand(async () => await this.deviceServices.RateApp());
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

        public int SelectedNotificationPreference
        {
            get
            {
                return ApplicationSettings.Instance.NotificationPreference;
            }

            set
            {
                if (ApplicationSettings.Instance.NotificationPreference != value)
                {
                    ApplicationSettings.Instance.NotificationPreference = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand LikeOnFacebook
        {
            get;
            private set;
        }

        public ICommand RateApp
        {
            get;
            private set;
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
