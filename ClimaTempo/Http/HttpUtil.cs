using System.Net.Http;
using System.Threading.Tasks;

namespace ClimaTempo.Http
{
    public abstract class HttpUtil
    {
        public static HttpResponseMessage Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }

        public static async Task<HttpResponseMessage> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(url);
            }
        }

    }
}

