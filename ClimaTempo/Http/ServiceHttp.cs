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

        static string urlApi = "https://api.darksky.net/forecast/faa103b5b3681ade900c611c71095265/-23.6207,-46.6072?lang=pt&units=ca&exclude=hourly,alerts,flags";

        public static async Task<Weather> GetWeather(double lati, double longe)
        {
            try
            {

                var resp = await HttpUtil.GetAsync(urlApi + lati + "," + longe);

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

    }
}
