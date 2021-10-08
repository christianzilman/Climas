using MV.Factory.DataAccess.Interfaces;
using MV.Factory.Domain.Implementaciones;
using MV.Factory.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MV.Factory.Service.Implementaciones
{
    public class ZonaClimaService : IZonaClimaService
    {
        private readonly IZonaClimaDAO _zonaClimaDAO;

        public ZonaClimaService(IZonaClimaDAO zonaClimaDAO)
        {
            _zonaClimaDAO = zonaClimaDAO;
        }

        public void AgregarZonaClima(ZonaClima zonaClima)
        {
            throw new NotImplementedException();
        }

        public IList<ZonaClima> ObtenerZonas()
        {
            return _zonaClimaDAO.ObtenerZonas();
        }
    }
}
