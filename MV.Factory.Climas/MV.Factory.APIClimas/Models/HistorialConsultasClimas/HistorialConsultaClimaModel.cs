using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.APIClimas.Models.HistorialConsultasClimas
{
    public class HistorialConsultaClimaModel
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Campo Zona de clima requerido")]
        public int IdZonaClima { get; set; }
        
        [Range(0,999999)]
        public decimal Temperatura { get; set; }
        
        [Range(0, 999999)]
        public decimal SensacionTermica { get; set; }

        [Required(ErrorMessage ="Campo Fecha Consulta requida")]
        public DateTime FechaConsulta { get; set; }


        public HistorialConsultaClima ModelToHistorialConsultaClima()
        {
            return new HistorialConsultaClima
            {
                FechaConsulta = FechaConsulta,
                SensacionTermica = SensacionTermica,
                Temperatura = Temperatura,
                IdZonaClima = IdZonaClima,
            };
        }
    }
}
