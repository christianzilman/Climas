using MV.Factory.DataAccess.Interfaces;
using MV.Factory.Domain.Implementaciones;
using MV.Factory.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MV.Factory.Service.Implementaciones
{
    public class HistorialConsultaClimaService : IHistorialConsultaClimaService
    {
        private readonly IHistorialConsultaClimaDAO _historialConsultaClimaDAO;

        public HistorialConsultaClimaService(IHistorialConsultaClimaDAO historialConsultaClimaDAO)
        {
            _historialConsultaClimaDAO = historialConsultaClimaDAO;
        }

        public void Agregar(HistorialConsultaClima historialConsultaClima)
        {
            _historialConsultaClimaDAO.Agregar(historialConsultaClima);
        }

        public IList<HistorialConsultaClima> ObtenerPorIdZonaFecha(int idZonaClima, DateTime fecha)
        {
            return _historialConsultaClimaDAO.ObtenerPorIdZonaFecha(idZonaClima, fecha);
        }
    }
}
