using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using MV.Factory.Domain.Implementaciones;
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

        [HttpPost] IActionResult Post(ZonaClima zonaClima)
        {
            try
            {
                _zonaClimaService.AgregarZonaClima(zonaClima);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al tratar agregar una zona de climas {nameof(Post)}: {ex}");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_zonaClimaService.ObtenerZonas());
            }
            catch (Exception ex)
            {
                Log.Error($"Error al tratar de obtener las zonas de climas {nameof(Get)}: {ex}");
                return BadRequest("Hubo un error");
            }            
        }
    }
}
