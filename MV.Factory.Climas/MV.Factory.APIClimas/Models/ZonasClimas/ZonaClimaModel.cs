using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.APIClimas.Models.ZonasClimas
{
    public class ZonaClimaModel
    {
        [Required(ErrorMessage ="Campo ID requerido")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Nombre requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Pais requerido")]
        public string Pais { get; set; }

        public ZonaClima ModelToZonaClima()
        {
            var zonaClima = new ZonaClima
            {
                ID = ID,
                Nombre = Nombre,
                Pais = Pais,
            };

            return zonaClima;
        }
    }
}
