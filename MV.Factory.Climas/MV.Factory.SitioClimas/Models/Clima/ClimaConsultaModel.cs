using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.Models.Clima
{
    public class ClimaConsultaModel
    {
        [Range(1,9999999, ErrorMessage = "Debe seleccionar Zona Clima")]                
        public int IdZonaClima { get; set; }

        [Display(Name = "Incluir histórico")]
        public bool DebeIncluirHistorico { get; set; }

        [Required(ErrorMessage ="Debe ingresar una fecha")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime FechaConsulta { get; set; }
    }
}
