using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWeatherApp.Views.Home.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> HttpRequest(string requestString);
    }

}
