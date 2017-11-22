using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel interface for all settings
    /// </summary>
    public interface ISettingsViewModel : IDataViewModel
    {
        /// <summary>
        /// Gets or sets whether the logging is enabled
        /// </summary>
        bool EnableLogging { get; set; }
        /// <summary>
        /// Gets or sets whether the transparent tile is enabled
        /// </summary>
        bool EnableTransparentTile { get; set; }
        /// <summary>
        /// Gets or sets whether location is used
        /// </summary>
        bool UseMyLocation { get; set; }
        /// <summary>
        /// Gets or sets the selected notification preference
        /// </summary>
        int SelectedNotificationPreference { get; set; }
        /// <summary>
        /// Like the app on facebook
        /// </summary>
        ICommand LikeOnFacebook { get; }
        /// <summary>
        /// Rate the app
        /// </summary>
        ICommand RateApp { get; }
    }
}