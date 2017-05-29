using MyFirstWeatherApp.Models;
using MyFirstWeatherApp.Views.Home.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWeatherApp.Views.Utilities
{
    public class DarkSkyService
    {
        private readonly string _apiKey;
        private readonly IHttpClient _httpClient;


        public DarkSkyService(string apiKey, IHttpClient httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentException($"{nameof(apiKey)} cannot be empty.");
            _apiKey = apiKey;
            _httpClient = httpClient ?? new ZHttpClient("https://api.darksky.net/");
        }


        public async Task<DarkSkyObject> GetForecast(double latitude, double longitude, OptionalParameters parameters = null)
        {
            try
            {
                var requestString = BuildRequestUri(latitude, longitude, parameters);
                var response = await _httpClient.HttpRequest(requestString);
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DarkSkyObject>(responseContent);

            }
            catch (Exception e)
            {
                return null;
            }

        }

        public string BuildRequestUri(double latitude, double longitude, OptionalParameters parameters)
        {
            var queryString = new StringBuilder($"forecast/{_apiKey}/{latitude:N4},{longitude:N4}");
            if (parameters?.UnixTimeInSeconds != null)
            {
                queryString.Append($",{parameters.UnixTimeInSeconds}");
            }

            if (parameters != null)
            {
                queryString.Append("?");
                if (parameters.DataBlocksToExclude != null)
                {
                    queryString.Append($"&exclude={String.Join(",", parameters.DataBlocksToExclude)}");
                }
                if (parameters.ExtendHourly != null && parameters.ExtendHourly.Value)
                {
                    queryString.Append("&extend=hourly");
                }
                if (!String.IsNullOrWhiteSpace(parameters.LanguageCode))
                {
                    queryString.Append($"&lang={parameters.LanguageCode}");
                }
                if (!String.IsNullOrWhiteSpace(parameters.MeasurementUnits))
                {
                    queryString.Append($"&units={parameters.MeasurementUnits}");
                }
            }

            return queryString.ToString();
        }

        public class OptionalParameters
        {
            public List<string> DataBlocksToExclude { get; set; }
            public bool? ExtendHourly { get; set; }
            public string LanguageCode { get; set; }
            public string MeasurementUnits { get; set; }
            public long? UnixTimeInSeconds { get; set; }
        }
    }
}
