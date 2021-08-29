using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reference.API.Entities;
using Reference.API.Model;
using Reference.API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _repository;
        private readonly ILogger<LocationController> _logger;
        public LocationController(ILocationRepository repository, ILogger<LocationController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LocationModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetLocations()
        {
            var Locations = await _repository.GetLocations();
            return Ok(Locations);
        }

        [HttpGet("{id:length(24)}", Name = "GetLocation")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LocationModel>> GetLocationById(string id)
        {
            var Location = await _repository.GetLocation(id);
            if (Location == null)
            {
                _logger.LogError($"Location with id: {id}, not found.");
                return NotFound();
            }
            return Ok(Location);
        }
        [HttpGet("{name}", Name = "GetLocationByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetLocationByName(string name)
        {
            var Location = await _repository.GetLocationByName(name);
            if (Location == null)
            {
                _logger.LogError($"Location with id: {name}, not found.");
                return NotFound();
            }
            return Ok(Location);
        }

        [HttpGet("{type}", Name = "GetLocationByType")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<LocationModel>>> GetLocationByType(string type)
        {
            var Location = await _repository.GetLocationByType(type);
            if (Location == null)
            {
                _logger.LogError($"Location with id: {type}, not found.");
                return NotFound();
            }
            return Ok(Location);
        }


        [HttpPost]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<LocationModel>> CreateLocation([FromBody] LocationModel location)
        {
            await _repository.CreateLocation(location);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationModel Location)
        {
            return Ok(await _repository.UpdateLocation(Location));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteLocation")]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLocationById(string id)
        {
            return Ok(await _repository.DeleteLocation(id));
        }
    }
}
