using MV.Factory.DataAccess.Interfaces;
using MV.Factory.Domain.Implementaciones;
using System.Collections.Generic;
using System.Linq;

namespace MV.Factory.DataAccess.Implementaciones
{
    public class ZonaClimaDAO : IZonaClimaDAO
    {
        private readonly ClimasContext _climasContext;

        public ZonaClimaDAO(ClimasContext climasContext)
        {
            _climasContext = climasContext;
        }

        public IList<ZonaClima> ObtenerZonas()
        {
            return _climasContext.ZonasClimas.ToList();
        }
    }
}
