using System;

namespace MV.Factory.Domain.Implementaciones
{
    public class HistorialConsultaClima
    {
        public int ID { get; set; }
        public int IdZonaClima { get; set; }
        public ZonaClima ZonaClima { get; set; } 
	    public decimal Temperatura { get; set; }
	    public decimal SensacionTermica { get; set; }
	    public DateTime FechaConsulta { get; set; }
    }
}
