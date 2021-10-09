using Microsoft.EntityFrameworkCore;
using MV.Factory.DataAccess.Interfaces;
using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MV.Factory.DataAccess.Implementaciones
{
    public class HistorialConsultaClimaDAO : IHistorialConsultaClimaDAO
    {
        private readonly ClimasContext _climasContext;

        public HistorialConsultaClimaDAO(ClimasContext climasContext)
        {
            _climasContext = climasContext;
        }

        public void Agregar(HistorialConsultaClima historialConsultaClima)
        {
            _climasContext.HistorialConsultaClimas.Add(historialConsultaClima);
            _climasContext.SaveChanges();
        }

        public IList<HistorialConsultaClima> ObtenerPorIdZonaFecha(int idZonaClima, DateTime fecha)
        {
            return _climasContext
                            .HistorialConsultaClimas
                            .Include(p => p.ZonaClima)
                            .Where(p => p.FechaConsulta.Date == fecha.Date && p.ZonaClima.ID == idZonaClima)                            
                            .ToList();
        }
    }
}
