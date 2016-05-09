using Epiphany.Model.Services;

namespace Epiphany.ViewModel
{
    public interface ISettingsViewModel : IDataViewModel
    {
        bool EnableLogging { get; set; }
        bool EnableTransparentTile { get; set; }
        bool UseMyLocation { get; set; }
    }
}