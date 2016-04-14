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
        Task LaunchUrl(string url);

        Task<GeoCoords> GetCoordinatesAsync();

        Task RateApp();
    }
}
