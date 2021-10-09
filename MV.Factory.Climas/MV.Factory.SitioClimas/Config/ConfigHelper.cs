using Microsoft.Extensions.Configuration;
using MV.Factory.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.Config
{
    public class ConfigHelper
    {
        private static IConfigurationRoot Configuracion()
        {
            var configBuilder = new ConfigurationBuilder();
            var environmentName = configBuilder.AddEnvironmentVariables().Build()["ASPNETCORE_ENVIRONMENT"];
            var configuration = configBuilder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }

        public static void ConfiguracionBaseDeDatos()
        {
            var configuracion = Configuracion();
            BaseDeDatosConfig.CONNECTION_EF_STRING = configuracion["BaseDeDatos:CONNECTION_EF_STRING"];
        }

        public static void ConfiguracionWebApiClima()
        {
            var configuracion = Configuracion();
            URLWebAPIClimaConfig.URL_WEBAPICLIMA = configuracion["WebApiClima:URL_WEBAPICLIMA"];
        }

        public static void ConfiguracionWebApiOpenWeathearMap()
        {
            var configuracion = Configuracion();
            URLWebAPIOpenWeatherMapConfig.URL_WEBAPI_OPENWEATHERMAP = configuracion["WebApiOpenWeathearMap:URL_WEBAPICLIMA_OPENWEATHERMAP"];
            URLWebAPIOpenWeatherMapConfig.API_KEY = configuracion["WebApiOpenWeathearMap:API_KEY"];

        }
    }
}
