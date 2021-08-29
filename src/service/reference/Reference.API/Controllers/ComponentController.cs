using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reference.API.Entities;
using Reference.API.Model;
using Reference.API.Repositories;
using Reference.API.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reference.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentRepository _repository;
        private readonly ILogger<ComponentController> _logger;
        public ComponentController(IComponentRepository repository, ILogger<ComponentController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ComponentModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComponentModel>>> GetComponents()
        {
            
            var Components = await _repository.GetComponents();

            return Ok(Components);
        }

        [HttpGet("{id:length(24)}", Name = "GetComponent")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ComponentModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ComponentModel>> GetComponentById(string id)
        {
            var Component = await _repository.GetComponent(id);
            if (Component == null)
            {
                _logger.LogError($"Component with id: {id}, not found.");
                return NotFound();
            }

            return Ok(Component);
        }

        [HttpGet("{name}", Name = "GetComponentByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(LocationModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ComponentModel>>> GetComponentByName(string name)
        {
            var Location = await _repository.GetComponentByName(name);
            if (Location == null)
            {
                _logger.LogError($"Component with id: {name}, not found.");
                return NotFound();
            }
            return Ok(Location);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ComponentModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ComponentModel>> CreateComponent([FromBody] CreateComponentDTO Component)
        {
            await _repository.CreateComponent(Component);

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ComponentModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateComponent([FromBody] ComponentModel Component)
        {
            return Ok(await _repository.UpdateComponent(Component));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteComponent")]
        [ProducesResponseType(typeof(ComponentModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteComponentById(string id)
        {
            return Ok(await _repository.DeleteComponent(id));
        }
    }
}
