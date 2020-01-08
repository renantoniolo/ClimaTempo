using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ClimaTempo.Geolocalizacao
{
    public static class MyGeolocator
    {

        public static async Task<Location> MyGeoNow()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                    return location;
                }
                else return null;

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return null;
            }
            
        }

    }
}
