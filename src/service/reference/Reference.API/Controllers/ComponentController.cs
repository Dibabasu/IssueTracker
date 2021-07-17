using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reference.API.Entities;
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
        [ProducesResponseType(typeof(IEnumerable<Component>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            var Components = await _repository.GetComponents();
            return Ok(Components);
        }

        [HttpGet("{id:length(24)}", Name = "GetComponent")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Component), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Component>> GetComponentById(string id)
        {
            var Component = await _repository.GetComponent(id);
            if (Component == null)
            {
                _logger.LogError($"Component with id: {id}, not found.");
                return NotFound();
            }
            return Ok(Component);
        }
       
        [HttpPost]
        [ProducesResponseType(typeof(Component), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Component>> CreateComponent([FromBody] Component Component)
        {
            await _repository.CreateComponent(Component);

            return CreatedAtRoute("GetComponent", new { id = Component.Id }, Component);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Component), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateComponent([FromBody] Component Component)
        {
            return Ok(await _repository.UpdateComponent(Component));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteComponent")]
        [ProducesResponseType(typeof(Component), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteComponentById(string id)
        {
            return Ok(await _repository.DeleteComponent(id));
        }
    }
}
