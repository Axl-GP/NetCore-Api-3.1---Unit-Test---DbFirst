using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiBahia_Estate.Models.BuildingSites;
using MiBahia_Estate.Models.Properties;
using MiBahia_Estate.Solares;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MiBahia_Estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingSitesController : ControllerBase
    {
        private readonly AsyncUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BuildingSitesController(AsyncUnitOfWork work, IMapper mapper, ILogger logger)
        {
            this._work = work;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingSiteDTO>>> Get()
        {
            var response = await _work.BuildingSites.GetAll();
            if (response != null)
            {
                var buildingSitesDTO = _mapper.Map<BuildingSiteDTO>(response);
                return Ok(buildingSitesDTO);
            }

            return NotFound();
        }

        [HttpGet("{id}", Name ="GetBuildingSite")]
        public async Task<ActionResult<BuildingSiteDTO>> Get(int id)
        {
            var response = await _work.BuildingSites.Get(id);
            if (response != null)
            {
                var buildingSiteDTO = _mapper.Map<BuildingSiteDTO>(response);
                return buildingSiteDTO;
            }
            return NotFound();
        }
        [HttpGet("{minimum:int?}/{maximum:int?}")]
        public async Task<ActionResult<IEnumerable<BuildingSiteDTO>>> Get(int minimum=0, int maximum=1800)
        {
            var response = await _work.BuildingSites.GetBuildingSitesbyPricePerMeter(minimum, maximum);
            if (response != null)
            {
                var buildingSiteDTO = _mapper.Map<BuildingSiteDTO>(response);
                return Ok(buildingSiteDTO);
            }
            return NotFound();

        }
        [HttpGet("{minimum:int?}/{maximum:int?}")]
        public async Task<ActionResult<IEnumerable<BuildingSiteDTO>>> GetBySize(int minimum=0, int maximum = 400)
        {
            var response = await _work.BuildingSites.GetBuildingSitesbySize(minimum, maximum);
            if (response != null)
            {
                var buildingSiteDTO = _mapper.Map<BuildingSiteDTO>(response);
                return Ok(buildingSiteDTO);
            }

            return NotFound();
        }
        [HttpGet("{outstanding}")]
        public async Task<ActionResult<IEnumerable<BuildingSiteDTO>>> GetOutstandingBuildingSites(bool outstanding)
        {
            var response = await _work.BuildingSites.GetOutstandingBuildingSites(outstanding);
            if (response != null)
            {
                var buildingSiteDTO = _mapper.Map<BuildingSiteDTO>(response);
                return Ok(buildingSiteDTO);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BuildingSiteITO buildingSite)
        {
            try
            {
            var buildingSiteDB = _mapper.Map<BuildingSite>(buildingSite);
            await _work.BuildingSites.Add(buildingSiteDB);
            await _work.PropertyAddress.AddRange(buildingSiteDB.PropertyAddresses);
            await _work.PropertyPhotos.AddImages(buildingSiteDB.PropertyPhotos);
            await _work.PropertyPrice.Add(buildingSiteDB.PropertyPrice);

            return CreatedAtRoute("GetBuildingSite", new { id = buildingSiteDB.Id });

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest();
            }

        }



    }
}
