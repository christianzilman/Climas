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

        public void Agregar(ZonaClima zonaClima)
        {
            _climasContext.ZonasClimas.Add(zonaClima);
            _climasContext.SaveChanges();
        }

        public IList<ZonaClima> Obtener()
        {
            return _climasContext.ZonasClimas.ToList();
        }

        public ZonaClima Obtener(int id)
        {
            return _climasContext.ZonasClimas.SingleOrDefault(p => p.ID == id);
        }
    }
}
