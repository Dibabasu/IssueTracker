using IssueTracker.Application.Features.IssueDetails.Command.Create;
using IssueTracker.Application.Features.IssueDetails.Command.Update;
using IssueTracker.Application.Features.IssueDetails.Query.GetIssues;
using IssueTracker.Application.Models;
using IssueTracker.Application.Services;
using IssueTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IssueTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTrackerController : ApiControllerBase
    {
        private readonly IIssueTrackerService _createIssueService;
        public IssueTrackerController(IIssueTrackerService createIssueService)
        {
            _createIssueService = createIssueService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<IssueDetail>>> GetTodoItemsWithPagination([FromQuery] GetIssuesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIssueDetailCommand command)
        {
            return await _createIssueService.CreateIssueDetailsAsync(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update( UpdateIssueDetailCommand command)
        {
          
            await Mediator.Send(command);

            return NoContent();
        }

     


    }
}
