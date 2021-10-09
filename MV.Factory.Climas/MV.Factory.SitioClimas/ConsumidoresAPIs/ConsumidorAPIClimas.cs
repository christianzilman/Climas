using MV.Factory.Domain.Config;
using MV.Factory.Domain.Implementaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.ConsumidoresAPIs
{
    public class ConsumidorAPIClimas
    {
        const string CONTENT_TYPE = "application/json";
        private static HttpClient _client = new HttpClient();

        public static async Task<HttpResponseMessage> AgregarHistorialConsultaClima(HistorialConsultaClima historialConsultaClima)
        {            
            var parameters = new Dictionary<string, object>
            {
                { "IdZonaClima", historialConsultaClima.IdZonaClima },
                { "Temperatura", historialConsultaClima.Temperatura },
                { "SensacionTermica", historialConsultaClima.SensacionTermica },
                { "FechaConsulta", historialConsultaClima.FechaConsulta},
            };

            var url = $"{URLWebAPIClimaConfig.URL_WEBAPICLIMA}/HistorialConsultasClimas";

            var objetoJson = JsonConvert.SerializeObject(parameters);

            var content = new StringContent(objetoJson.ToString(), Encoding.UTF8, CONTENT_TYPE);

            var response = await _client.PostAsync(url, content);

            return response;
        }

        public static async Task<IList<ZonaClima>> ObtenerZonasClimas()
        {
            var url = $"{URLWebAPIClimaConfig.URL_WEBAPICLIMA}/ZonasClimas";

            var response = await _client.GetAsync(url);

            var zonasClimas = JsonConvert.DeserializeObject<List<ZonaClima>>(await response.Content.ReadAsStringAsync());

            return zonasClimas.OrderBy(x => x.Nombre).ToList();
        }

        public static async Task<ZonaClima> ObtenerZonaClima(int id)
        {
            var url = $"{URLWebAPIClimaConfig.URL_WEBAPICLIMA}/ZonasClimas/{id}";

            var response = await _client.GetAsync(url);

            var model = JsonConvert.DeserializeObject<ZonaClima>(await response.Content.ReadAsStringAsync());

            return model;
        }

        public static async Task<IList<HistorialConsultaClima>> ObtenerHistorialConsultaClima(int idZonaClima, DateTime fechaConsulta)
        {
            var url = $"{URLWebAPIClimaConfig.URL_WEBAPICLIMA}/HistorialConsultasClimas/{idZonaClima}/{fechaConsulta:yyyy-MM-dd}";

            var response = await _client.GetAsync(url);

            var historialConsultasClimas = JsonConvert.DeserializeObject<List<HistorialConsultaClima>>(await response.Content.ReadAsStringAsync());

            return historialConsultasClimas.OrderByDescending(x => x.FechaConsulta).ToList();
        }
    }
}
