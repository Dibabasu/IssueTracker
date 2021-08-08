using IssueTracker.Application.Features.IssueDetails.Command.Create;
using IssueTracker.Application.Features.IssueDetails.Command.Update;
using IssueTracker.Application.Features.IssueDetails.Query.GetIssues;
using IssueTracker.Application.Features.LastTickets.Query.GetLastTicket;
using IssueTracker.Application.Models;
using IssueTracker.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTrackerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICreateIssueService createIssue;
        public IssueTrackerController(IMediator mediator, ICreateIssueService createIssueService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            createIssue = createIssueService;


        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateIssueDetailCommand command)
        {
            return await createIssue.CreateIssueDetailsAsync(command);
        }

        [HttpGet]
        public async Task<ActionResult<LastTicketDTO>> GetLast([FromQuery] GetLastTicketQuery query)
        {
            return await _mediator.Send(query);
        }




    }
}
