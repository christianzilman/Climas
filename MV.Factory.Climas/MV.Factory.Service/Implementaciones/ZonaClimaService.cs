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

        public void Agregar(ZonaClima zonaClima)
        {

            _zonaClimaDAO.Agregar(zonaClima);
        }

        public IList<ZonaClima> Obtener()
        {
            return _zonaClimaDAO.Obtener();
        }
    }
}
