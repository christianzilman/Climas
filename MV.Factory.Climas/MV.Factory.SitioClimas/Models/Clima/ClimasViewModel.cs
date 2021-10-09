using Microsoft.AspNetCore.Mvc.Rendering;
using MV.Factory.Domain.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.Models.Clima
{
    public class ClimasViewModel
    {
        public ClimaConsultaModel ClimaConsultaModel { get; set; }
        public ClimaModel ClimaModel { get; set; }

        public IList<ClimaModel> HistorialConsultaClima { get; set; }

        public IList<SelectListItem> ZonasClimas { get; set; }

        public void IniciarValores(IList<ZonaClima> zonasClimas)
        {
            ZonasClimas = new List<SelectListItem>();

            ZonasClimas.Add(
                    new SelectListItem
                    {
                        Text = "Seleccione la Ciudad",
                        Value = 0.ToString(),
                    }
                );

            foreach (var zonaClima in zonasClimas)
            {
                ZonasClimas.Add(
                    new SelectListItem
                    {
                        Text = $"{zonaClima.Nombre} - {zonaClima.Pais}",
                        Value = zonaClima.ID.ToString(),
                        Selected = ClimaConsultaModel?.IdZonaClima == zonaClima.ID,
                    }
                );
            }
        }
    }
}
