using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace MV.Factory.Service.Interfaces
{
    public interface IHistorialConsultaClimaService
    {
        void Agregar(HistorialConsultaClima historialConsultaClima);
        IList<HistorialConsultaClima> ObtenerPorIdZonaFecha(int idZonaClima, DateTime fecha);
    }
}
