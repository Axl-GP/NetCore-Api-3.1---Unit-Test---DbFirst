using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiBahia_Estate.Models.Properties;
using MiBahia_Estate.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MiBahia_Estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly bahia_estateContext _context;
        private readonly AsyncUnitOfWork _work;
        private readonly IMapper _mapper;

        public IAsyncHouseRepository Houses { get; private set; }

        public HousesController(bahia_estateContext context, AsyncUnitOfWork work, IMapper mapper)
        {
            _work = work;
            _mapper = mapper;
            this._context = context;
            this._work = work;
            Houses = new AsyncHouseRepository(_context);
        }
        #region Get Endpoints
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> Get()
        {
            var response = await _work.Houses.GetAll();

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDTO>> GetProperties(int id)
        {
            var response = await _work.Houses.Get(id);
            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }

            return NotFound();

        }

        [HttpGet("{rooms}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByRooms(int rooms)
        {
            var response = await _work.Houses.SearchByRooms(rooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }

            return NotFound();
        }

        [HttpGet("{Bathrooms}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByBathrooms(int Bathrooms)
        {
            var response = await _work.Houses.SearchByBathrooms(Bathrooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }


        [HttpGet("{rooms}/{bathrooms}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetProperties(int rooms,int bathrooms)
        {
            var response = await _work.Houses.SearchByRoomsBathrooms(rooms,bathrooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{outstanding}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetOutstandingProperties(bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingProperties(outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }


        [HttpGet("{rooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetOutstandingPropertiesByRooms(int rooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByRooms(rooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }



        [HttpGet("{bathrooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetOutstandingPropertiesByBathrooms(int bathrooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByBathrooms(bathrooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{rooms}/{bathrooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetOutstandingPropertiesByRoomsBathrooms(int rooms,int bathrooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByRoomsAndBathrooms(rooms, bathrooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<PropertyDTO>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }
        #endregion
        /*
                [HttpPost]
                public async Task<ActionResult<PropertyDTO>> Post([FromBody] Property)
                {

                    return CreatedAtRouteResult();
                }
        */

    }
}
