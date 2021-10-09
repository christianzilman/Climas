using Microsoft.AspNetCore.Mvc;
using MV.Factory.Domain.Implementaciones;
using MV.Factory.SitioClimas.ConsumidoresAPIs;
using MV.Factory.SitioClimas.Models.Clima;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MV.Factory.SitioClimas.Controllers
{
    public class ClimaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var vm = new ClimasViewModel();
                vm.ClimaModel = new ClimaModel();
                vm.ClimaConsultaModel = new ClimaConsultaModel
                {
                    FechaConsulta = DateTime.Now.Date,
                };

                var zonasClimas = await ConsumidorAPIClimas.ObtenerZonasClimas();

                vm.IniciarValores(zonasClimas);

                return View(vm);
            }
            catch (Exception ex)
            {
                Log.Error($"Hubo un error al ingresar a la pagina de clima action {nameof(Index)} error {ex.Message}");
                return RedirectToAction("Error", "Home");
            }            
        }

        public async Task<IActionResult> ConsultarClima(ClimaConsultaModel climaConsultaModel)
        {
            try
            {
                var vm = new ClimasViewModel();
                vm.ClimaConsultaModel = climaConsultaModel;
                vm.ClimaModel = new ClimaModel();

                var zonasClimas = await ConsumidorAPIClimas.ObtenerZonasClimas();
                vm.IniciarValores(zonasClimas);

                
                if (ModelState.IsValid)
                {
                    var openWeatherMapModelModel = await ConsumidorAPIOpenWeatherMap.ObtenerDatosClima(climaConsultaModel.IdZonaClima);

                    vm.ClimaModel.Temperatura = openWeatherMapModelModel.OpenWeatherMapPropiedadPrincipal.TemperaturaEnGrado;
                    vm.ClimaModel.SensacionTermica = openWeatherMapModelModel.OpenWeatherMapPropiedadPrincipal.SensacionTermicaEnGrado;

                    var historialesConsultasZonasClimas = await ConsumidorAPIClimas.ObtenerHistorialConsultaClima(climaConsultaModel.IdZonaClima, climaConsultaModel.FechaConsulta);

                    vm.HistorialConsultaClima = historialesConsultasZonasClimas.Select(p => new ClimaModel
                    {
                        ZonaClimaNombre = p.ZonaClima.Nombre,
                        Pais = p.ZonaClima.Pais,
                        Temperatura = p.Temperatura,
                        SensacionTermica = p.SensacionTermica,
                        FechaConsulta = p.FechaConsulta,
                    }).ToList();

                    if (climaConsultaModel.DebeIncluirHistorico)
                    {
                        var historialConsultaClima = new HistorialConsultaClima
                        {
                            FechaConsulta = DateTime.Now,
                            IdZonaClima = climaConsultaModel.IdZonaClima,
                            Temperatura = vm.ClimaModel.Temperatura,
                            SensacionTermica = vm.ClimaModel.SensacionTermica,
                        };

                        await ConsumidorAPIClimas.AgregarHistorialConsultaClima(historialConsultaClima);
                    }                    
                }

                if (vm.ClimaConsultaModel?.IdZonaClima > 0)
                {
                    var zonaClima = await ConsumidorAPIClimas.ObtenerZonaClima(vm.ClimaConsultaModel.IdZonaClima);

                    vm.ClimaModel.CiudadNombreCompleto = $"{zonaClima.Nombre}, {zonaClima.Pais}";
                }

                return View("Index", vm);
            }
            catch (Exception ex)
            {
                Log.Error($"Hugo un error al realizar la consulta de climas action {nameof(ConsultarClima)} error {ex.Message}");
                return RedirectToAction("Error","Home");
            }            
        }
    }
}
