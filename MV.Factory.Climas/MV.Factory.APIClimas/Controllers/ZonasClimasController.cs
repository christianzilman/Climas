using Microsoft.AspNetCore.Mvc;
using MV.Factory.APIClimas.Models.ZonasClimas;
using MV.Factory.Service.Interfaces;
using Serilog;
using System;

namespace MV.Factory.APIClimas.Controllers
{
    [Route("[controller]")]
    [ApiController]    
    public class ZonasClimasController: ControllerBase
    {
        private readonly IZonaClimaService _zonaClimaService;

        public ZonasClimasController(IZonaClimaService zonaClimaService)
        {
            _zonaClimaService = zonaClimaService;
        }

        [HttpPost] IActionResult Post(ZonaClimaModel zonaClima)
        {
            try
            {
                _zonaClimaService.Agregar(zonaClima.ModelToZonaClima());

                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"Error al tratar agregar una zona de climas {nameof(Post)}: {ex}");
                return BadRequest("Hubo un error");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_zonaClimaService.Obtener());
            }
            catch (Exception ex)
            {
                Log.Error($"Error al tratar de obtener las zonas de climas {nameof(Get)}: {ex}");
                return BadRequest("Hubo un error");
            }            
        }
    }
}
