using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MV.Factory.DataAccess;
using MV.Factory.DataAccess.Implementaciones;
using MV.Factory.DataAccess.Interfaces;
using MV.Factory.Domain.Config;
using MV.Factory.Service.Implementaciones;
using MV.Factory.Service.Interfaces;

namespace MV.Factory.Dependecy
{
    public class DependecyStartup
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddDbContext<ClimasContext>(options =>
                options.UseSqlServer(BaseDeDatosConfig.CONNECTION_EF_STRING));

            //DAO
            services.AddTransient<IZonaClimaDAO, ZonaClimaDAO>();


            //Service
            services.AddTransient<IZonaClimaService, ZonaClimaService>();
        }
    }
}
