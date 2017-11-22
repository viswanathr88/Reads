using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;

namespace Epiphany.View.Services
{
    sealed class DeviceServices : IDeviceServices
    {
        public async Task<GeoCoords> GetCoordinatesAsync()
        {
            Windows.Devices.Geolocation.Geolocator gl = new Windows.Devices.Geolocation.Geolocator();

            Windows.Devices.Geolocation.Geoposition position = await gl.GetGeopositionAsync();

            GeoCoords coords = new GeoCoords()
            {
                Latitude = position.Coordinate.Point.Position.Latitude,
                Longitude = position.Coordinate.Point.Position.Longitude
            };

            return coords;
        }

        public async Task LaunchUrl(string url)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute));
        }

        public Task RateApp()
        {
            throw new NotImplementedException();
        }
    }
}
