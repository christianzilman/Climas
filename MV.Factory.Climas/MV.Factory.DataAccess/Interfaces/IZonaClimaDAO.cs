﻿using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace MV.Factory.DataAccess.Interfaces
{
    public interface IZonaClimaDAO
    {
        IList<ZonaClima> ObtenerZonas();
    }
}