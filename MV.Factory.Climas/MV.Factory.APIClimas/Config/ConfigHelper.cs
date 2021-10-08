using Microsoft.Extensions.Configuration;
using MV.Factory.Domain.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.APIClimas.Config
{
    public static class ConfigHelper
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
    }
}
