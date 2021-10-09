using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.ConsumidoresAPIs.Models
{
    public class OpenWeatherMapPropiedadPrincipal
    {
        [JsonProperty("temp")]
        public decimal Temperatura { get; set; }

        public decimal TemperaturaEnGrado
        {
            get
            {
                return Temperatura - 273.15m;
            }
        }

        [JsonProperty("feels_like")]
        public decimal SensacionTermica { get; set; }

        public decimal SensacionTermicaEnGrado
        {
            get
            {
                return SensacionTermica - 273.15m;
            }
        }

        [JsonProperty("temp_min")]
        public decimal TempMin { get; set; }

        [JsonProperty("temp_max")]
        public decimal TempMax { get; set; }

        [JsonProperty("pressure")]
        public int Pressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class OpenWeatherMapModelModel
    {
        [JsonProperty("main")]
        public OpenWeatherMapPropiedadPrincipal OpenWeatherMapPropiedadPrincipal { get; set; }
    }
}
