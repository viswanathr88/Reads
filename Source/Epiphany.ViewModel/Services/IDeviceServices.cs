using System.Threading.Tasks;

namespace Epiphany.ViewModel.Services
{
    public sealed class GeoCoords
    {
        public double Latitude = 0.0;

        public double Longitude = 0.0;
    }

    public interface IDeviceServices
    {
        /// <summary>
        /// Launch a url
        /// </summary>
        /// <param name="url">Url to launch</param>
        /// <returns></returns>
        Task LaunchUrl(string url);
        /// <summary>
        /// Get geo coordinates asynchronoously
        /// </summary>
        /// <returns></returns>
        Task<GeoCoords> GetCoordinatesAsync();
        /// <summary>
        /// Rate the app
        /// </summary>
        /// <returns></returns>
        Task RateApp();
    }
}
