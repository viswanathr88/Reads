
namespace Epiphany.ViewModel.Services
{
    /// <summary>
    /// Interface for a URL launcher
    /// </summary>
    public interface IUrlLauncher
    {
        /// <summary>
        /// Launch a given url
        /// </summary>
        /// <uri name="url">url</uri>
        void Launch(string url);
    }
}
