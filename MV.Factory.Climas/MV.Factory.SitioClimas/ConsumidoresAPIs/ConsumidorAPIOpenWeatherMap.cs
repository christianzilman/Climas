using MV.Factory.Domain.Config;
using MV.Factory.SitioClimas.ConsumidoresAPIs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.ConsumidoresAPIs
{
    public class ConsumidorAPIOpenWeatherMap
    {
        const string CONTENT_TYPE = "application/json";
        private static HttpClient _client = new HttpClient();

        public static async Task<OpenWeatherMapModelModel> ObtenerDatosClima(int idZonaClima)
        {
            var url = $"{URLWebAPIOpenWeatherMapConfig.URL_WEBAPI_OPENWEATHERMAP}/weather?id={idZonaClima}&APPID={URLWebAPIOpenWeatherMapConfig.API_KEY}";

            var response = await _client.GetAsync(url);

            var model = JsonConvert.DeserializeObject<OpenWeatherMapModelModel>(await response.Content.ReadAsStringAsync());

            return model;
        }
    }
}
