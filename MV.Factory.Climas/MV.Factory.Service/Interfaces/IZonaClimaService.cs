using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace MV.Factory.Service.Interfaces
{
    public interface IZonaClimaService
    {
        IList<ZonaClima> Obtener();
        void Agregar(ZonaClima zonaClima);
        ZonaClima Obtener(int id);
    }
}
