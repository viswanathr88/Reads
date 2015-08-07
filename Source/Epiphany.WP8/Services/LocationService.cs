using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Epiphany.View.Services
{
    sealed class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetCoordinatesAsync()
        {
            Geolocator geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 1000;
            Geoposition geoposition = await geolocator.GetGeopositionAsync();
            return new GeoCoords()
            {
                Latitude = geoposition.Coordinate.Latitude,
                Longitude = geoposition.Coordinate.Longitude
            };
        }
    }
}
