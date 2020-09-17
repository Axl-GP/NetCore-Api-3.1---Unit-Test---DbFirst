using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BahiaRealEstate.Models;
using BahiaRealEstate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BahiaRealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolaresController : ControllerBase
    {
        private readonly SolarCrud service;

        public SolaresController(SolarCrud _service)
        {
            service = _service;
        }

        [HttpGet]
        [Route("obtener-solares")]
        public async Task<IActionResult> getSolares()
        {
            IEnumerable<Solar> resultado = await service.getSolares();

            if (resultado!=null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-solar/{id}")]
        public async Task<IActionResult> getSolar(int id)
        {
            Solar resultado = await service.getSolar(id);

            if (resultado != null) 
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("obtener-solares/{destacado}")]
        public async Task<IActionResult> getSolarDestacado(bool destacado)
        {
            IEnumerable<Solar> resultado = await service.getSolaresDestacadas(destacado);

            if (resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
          [Route("agregar-solares")]
        public async Task<IActionResult> addSolar([FromBody]Solar solar)
        {
            var resultado = await service.AddSolar(solar,solar.SolarPrecio,solar.SolarDireccion,solar.SolarFoto.ToList(),solar.TipoInmuebleid);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar-solares/{solar},{direccion},{precio},{foto},{id}")]
        public async Task<IActionResult> editSolar(Solar solar, SolarDireccion direccion, SolarPrecio precio, SolarFoto foto, int id)
        {
            var resultado = await service.EditSolar(solar, precio, direccion,foto, id);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }*/
        [HttpDelete]
        [Route("borrar-solares/{id}")]
        public async Task<IActionResult> deleteSolar(int id)
        {
            var resultado = await service.DeleteSolar(id);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

       
    }
}