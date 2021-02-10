using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiBahia_Estate.Models.Houses;
using MiBahia_Estate.Models.Properties;
using MiBahia_Estate.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}", Name ="GetProperty")]
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
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PropertyITO property)
        {
            if (property != null)
            {

                var propertyDB = _mapper.Map<House>(property);
                await _work.Houses.Add(propertyDB);
                await _work.PropertyPrice.Add(propertyDB.PropertyPrice);
                await _work.PropertyAddress.AddRange(propertyDB.PropertyAddresses);
                await _work.PropertyPhotos.AddRange(propertyDB.PropertyPhotos);

                await _work.Complete();

                _work.Dispose();
                var propertyDTO = _mapper.Map<PropertyDTO>(propertyDB);
       
                return new CreatedAtRouteResult("GetProperty", new {id= propertyDTO.Id }, propertyDTO);
            }
            return BadRequest();
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] HouseITO property)
        {
            var response =await _work.Houses.Get(id);
            if (response != null)
            {
                var propertyDB = _mapper.Map<House>(property);
                response.House = propertyDB.House;
                response.PropertyAddresses = propertyDB.PropertyAddresses;
                response.PropertyPrice = propertyDB.PropertyPrice;
                response.PropertyPhotos = propertyDB.PropertyPhotos;

                await _work.Complete();
                _work.Dispose();

                return NoContent();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<HouseITO> property)
        {
            if (property == null)
            {
                return BadRequest();
            }

            var propertyDB = await _work.Houses.Get(id);

            if (propertyDB == null)
            {
                return NotFound();
            }

            var houseITO = _mapper.Map<HouseITO>(property);

            property.ApplyTo(houseITO, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            _mapper.Map(houseITO, propertyDB);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _work.Complete();
            _work.Dispose();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _work.Houses.Get(id);

            if (response != null)
            {
                _work.Houses.Remove(response);
                await _work.Complete();
                _work.Dispose();
                return NoContent();
            }
            return BadRequest();


        }


    }
}
