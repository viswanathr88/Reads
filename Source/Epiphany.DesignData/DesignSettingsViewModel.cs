using System;
using System.Windows.Input;
using Epiphany.ViewModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignSettingsViewModel : DesignBaseViewModel, ISettingsViewModel
    {
        public DesignSettingsViewModel()
        {
            EnableLogging = false;
            EnableTransparentTile = true;
            UseMyLocation = true;
            SelectedNotificationPreference = 1;
        }
        public bool EnableLogging
        {
            get;
            set;
        }

        public bool EnableTransparentTile
        {
            get;
            set;
        }

        public ICommand LikeOnFacebook
        {
            get;
        }

        public ICommand RateApp
        {
            get;
        }

        public int SelectedNotificationPreference
        {
            get;
            set;
        }

        public bool UseMyLocation
        {
            get;
            set;
        }
    }
}
