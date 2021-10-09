using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.Models.Clima
{
    public class ClimaModel
    {
        public string ZonaClimaNombre { get; set; }
        public string Pais { get; set; }
        public string CiudadNombreCompleto { get; set; }
        public decimal Temperatura { get; set; }
        public decimal SensacionTermica { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
