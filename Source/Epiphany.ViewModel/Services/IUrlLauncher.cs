
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
        /// <param name="url">url</param>
        void Launch(string url);
    }
}
