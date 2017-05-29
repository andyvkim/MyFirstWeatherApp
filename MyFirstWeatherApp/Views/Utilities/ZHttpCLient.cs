using MyFirstWeatherApp.Views.Home.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MyFirstWeatherApp.Views.Utilities
{
    public class ZHttpClient : IHttpClient
    {
        public readonly string _baseUri = string.Empty;

        public ZHttpClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task<HttpResponseMessage> HttpRequest(string requestString)
        {
            using (var handler = new HttpClientHandler())
            {
              
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUri);
                    return await client.GetAsync(requestString);
                }
            }
        }
    }

}