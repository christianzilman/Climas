using Microsoft.AspNetCore.Mvc;
using MV.Factory.APIClimas.Models.HistorialConsultasClimas;
using MV.Factory.Service.Interfaces;
using Serilog;
using System;

namespace MV.Factory.APIClimas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistorialConsultasClimasController: ControllerBase
    {
        private readonly IHistorialConsultaClimaService _historialConsultaClimaService;

        public HistorialConsultasClimasController(IHistorialConsultaClimaService historialConsultaClimaService)
        {
            _historialConsultaClimaService = historialConsultaClimaService;
        }

        [HttpPost]
        public IActionResult Post(HistorialConsultaClimaModel historialConsultaClimaModel)
        {
            try
            {
                _historialConsultaClimaService.Agregar(historialConsultaClimaModel.ModelToHistorialConsultaClima());

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"Error en el metodo {nameof(Post)} al intentar realizar el alta de un historial de consulta error {ex.Message}");
                return BadRequest("Hubo un error");
            }
        }


        [HttpGet("{idZonaClima}/{fechaConsulta}")]

        public IActionResult Get(int idZonaClima, DateTime fechaConsulta)
        {
            try
            {
                var historialConsultasClimas = _historialConsultaClimaService.ObtenerPorIdZonaFecha(idZonaClima, fechaConsulta);
                return Ok(historialConsultasClimas);
            }
            catch (Exception ex)
            {
                Log.Error($"Error en el metodo {nameof(Get)} al intentar realizar la consulta del historial de consulta error {ex.Message}");
                return BadRequest("Hubo un error");
            }
        }
    }
}
