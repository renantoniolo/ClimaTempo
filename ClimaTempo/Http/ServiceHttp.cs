using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ClimaTempo.Model;
using Newtonsoft.Json;

namespace ClimaTempo.Http
{
    public static class ServiceHttp
    {

        private static string _key = "faa103b5b3681ade900c611c71095265";

        private static string _keyGoogle = "AIzaSyADbk0dUoSM3fDm8K34nP4P_bMjCvUng68";


        public static async Task<Weather> GetWeather(double lati, double longe)
        {
            try
            {
                var url = "https://api.darksky.net/forecast/" + _key + "/" + Math.Round(lati, 6).ToString().Replace(',', '.') + "," + Math.Round(longe, 6).ToString().Replace(',', '.') + "?lang=pt&units=ca&exclude=hourly,alerts,flags";

                var resp = await HttpUtil.GetAsync(url);

                if (resp.IsSuccessStatusCode)
                {
                    var responseStr = await resp.Content.ReadAsStringAsync();

                    var weather = JsonConvert.DeserializeObject<Weather>(responseStr);

                    return weather;
                }
                else return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

        public static async Task<String> GetCity(double lati, double longe)
        {
            try
            {
                var url = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + Math.Round(lati, 6).ToString().Replace(',','.') + "," + Math.Round(longe, 6).ToString().Replace(',', '.') + "&key=" + _keyGoogle;

                var resp = await HttpUtil.GetAsync(url);

                if (resp.IsSuccessStatusCode)
                {
                    var responseStr = await resp.Content.ReadAsStringAsync();

                    var city = JsonConvert.DeserializeObject<City>(responseStr);

                    if (city.Results == null) return null;

                    return city.Results[0].AddressComponents[3].LongName;
                }
                else return null;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }

    }
}
