using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BahiaRealEstate.Services;
using BahiaRealEstate.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace BahiaRealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadesController : ControllerBase
    {
        private readonly PropiedadCrud service;

        public PropiedadesController(PropiedadCrud _service)
        {
            service = _service;
        }

        /*Empezamos con los GET*/
        [HttpGet]
        [Route("obtener-propiedades")]
        public async Task<IActionResult> getPropiedades()
        {
         
           IEnumerable<Propiedad> propiedades = await service.getPropiedades();

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpGet]
        [Route("obtener-propiedad/{id}")]
        public async Task<IActionResult> getPropiedad(int id)
        {
            Propiedad propiedad = await service.getPropiedad(id);

            if (propiedad != null)
            {
                return Ok(propiedad);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-habitaciones/{cuartos}")]
        public async Task<IActionResult> getPropiedadesPorHabitacion(int cuartos)
        {
            IEnumerable<Propiedad> propiedad = await service.getPropiedadesCuartos(cuartos);

            if (propiedad != null)
            {
                return Ok(propiedad);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-duchas/{duchas}")]
        public async Task<IActionResult> getPropiedadesPorDuchas(int duchas)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesDuchas(duchas);

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-duchas-habitaciones/{duchas},{cuartos}")]
        public async Task<IActionResult> getPropiedadesPorDuchasYHabitaciones(int duchas, int cuartos)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesDuchaCuarto(duchas, cuartos);
            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-destacado/{destacado}")]
        public async Task<IActionResult> getPropiedadesDestacadas(bool destacado)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesDestacadas(destacado);

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-por-duchas-destacado/{duchas},{destacado}")]
        public async Task<IActionResult> getPropiedadesDuchaDestacado(int duchas,bool destacado)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesDuchaDestacado(duchas,destacado);

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-habitaciones-destacado/{cuartos},{destacado}")]
        public async Task<IActionResult> getPropiedadesCuartosDestacado(int cuartos,bool destacado)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesCuartoDestacado(cuartos,destacado);

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("obtener-propiedad-duchas-habitaciones-destacado/{duchas},{cuartos},{destacado}")]
        public async Task<IActionResult> getPropiedadesPorDuchaCuartoDestacadas(int duchas, int cuartos,bool destacado)
        {
            IEnumerable<Propiedad> propiedades = await service.getPropiedadesCuartoDuchaDestacado(duchas,cuartos,destacado);

            if (propiedades != null)
            {
                return Ok(propiedades);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("agregar-propiedad")]
        public async Task<IActionResult> addPropiedad([FromBody]Propiedad propiedad)
        {
               var resultado = await service.AddPropiedad(propiedad, propiedad.PropiedadPrecio, propiedad.PropiedadDireccion,propiedad.PropiedadFoto.ToList());

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
        [Route("editar-propiedad/{id}")]
        public async Task<IActionResult> editPropiedad([FromBody]Propiedad propiedad, int id)
        {
            var resultado = await service.EditPropiedad(propiedad, propiedad.PropiedadPrecio, propiedad.PropiedadDireccion, propiedad.PropiedadFoto.ToList(), id);

            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{id}")]
        [Route("eliminar-propiedad/{id}")]
        public async Task<IActionResult> deletePropiedad(int id)
        {
            var resultado = await service.DeletePropiedad(id);

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