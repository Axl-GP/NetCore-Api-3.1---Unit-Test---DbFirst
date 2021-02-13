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
        public async Task<ActionResult<IEnumerable<HouseDTO>>> Get()
        {
            var response = await _work.Houses.GetAll();

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{id}", Name ="GetProperty")]
        public async Task<ActionResult<HouseDTO>> GetProperties(int id)
        {
            var response = await _work.Houses.Get(id);
            if (response != null)
            {
                var responseDTO = _mapper.Map<HouseDTO>(response);
                return Ok(responseDTO);
            }

            return NotFound();

        }

        [HttpGet("{rooms}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetPropertiesByRooms(int rooms)
        {
            var response = await _work.Houses.SearchByRooms(rooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }

            return NotFound();
        }

        [HttpGet("{Bathrooms}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetPropertiesByBathrooms(int Bathrooms)
        {
            var response = await _work.Houses.SearchByBathrooms(Bathrooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }


        [HttpGet("{rooms}/{bathrooms}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetProperties(int rooms,int bathrooms)
        {
            var response = await _work.Houses.SearchByRoomsBathrooms(rooms,bathrooms);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{outstanding}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetOutstandingProperties(bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingProperties(outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }


        [HttpGet("{rooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetOutstandingPropertiesByRooms(int rooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByRooms(rooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }



        [HttpGet("{bathrooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetOutstandingPropertiesByBathrooms(int bathrooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByBathrooms(bathrooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }

        [HttpGet("{rooms}/{bathrooms}/{outstanding}")]
        public async Task<ActionResult<IEnumerable<HouseDTO>>> GetOutstandingPropertiesByRoomsBathrooms(int rooms,int bathrooms, bool outstanding)
        {
            var response = await _work.Houses.SearchOutstandingPropertiesByRoomsAndBathrooms(rooms, bathrooms, outstanding);

            if (response != null)
            {
                var responseDTO = _mapper.Map<IEnumerable<HouseDTO>>(response);
                return Ok(responseDTO);
            }
            return NotFound();
        }
        #endregion

        #region Post, Put, Patch and Delete Endpoints
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] HouseITO property)
        {
            if (property != null)
            {
                var houseDB = _mapper.Map<House>(property);
                await _work.Houses.Add(houseDB);
                await _work.PropertyPrice.Add(houseDB.PropertyPrice);
                await _work.PropertyAddress.AddRange(houseDB.PropertyAddresses);
                await _work.PropertyPhotos.AddImages(houseDB.PropertyPhotos);

                await _work.Complete();

                _work.Dispose();
                var houseDTO = _mapper.Map<HouseDTO>(houseDB);
       
                return new CreatedAtRouteResult("GetProperty", new {id= houseDB.Id }, houseDTO);
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
        #endregion

    }
}
