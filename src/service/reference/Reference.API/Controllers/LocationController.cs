using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reference.API.Entities;
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
        [ProducesResponseType(typeof(IEnumerable<Location>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            var Locations = await _repository.GetLocations();
            return Ok(Locations);
        }

        [HttpGet("{id:length(24)}", Name = "GetLocation")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Location>> GetLocationById(string id)
        {
            var Location = await _repository.GetLocation(id);
            if (Location == null)
            {
                _logger.LogError($"Location with id: {id}, not found.");
                return NotFound();
            }
            return Ok(Location);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Location>> CreateLocation([FromBody] Location Location)
        {
            await _repository.CreateLocation(Location);

            return CreatedAtRoute("GetLocation", new { id = Location.Id }, Location);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLocation([FromBody] Location Location)
        {
            return Ok(await _repository.UpdateLocation(Location));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteLocation")]
        [ProducesResponseType(typeof(Location), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteLocationById(string id)
        {
            return Ok(await _repository.DeleteLocation(id));
        }
    }
}
