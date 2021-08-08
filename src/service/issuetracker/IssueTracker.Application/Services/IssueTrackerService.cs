using IssueTracker.Application.Features.IssueDetails.Command.Create;
using IssueTracker.Application.Features.LastTickets.Command.CreateLastTicket;
using IssueTracker.Application.Features.LastTickets.Command.UpdateLastTicket;
using IssueTracker.Application.Features.LastTickets.Query.GetLastTicket;
using MediatR;
using System;
using System.Threading.Tasks;

namespace IssueTracker.Application.Services
{
    public class IssueTrackerService : IIssueTrackerService
    {
        private readonly ISender _mediator;

        public IssueTrackerService(ISender mediator)
        {
            _mediator = mediator;
        }
        public async Task<int> CreateIssueDetailsAsync(CreateIssueDetailCommand command)
        {
            var TicketNo = await GetTicketNumber();
            command.TicketNumber = TicketNo;

            return await _mediator.Send(command);
        }
        private async Task<string> GetTicketNumber()
        {
            GetLastTicketQuery getLastTicketQuery = new()
            {
                Year = DateTime.UtcNow.Year
            };
            var lastTicket = await _mediator.Send(getLastTicketQuery);

            if (!lastTicket.YearExsists)
            {
                await CreateTicket();
            }
            else
            {
                await UpdateTicket(lastTicket.LastTicketNumber);
            }

            return lastTicket.LastTicket;
        }
        private async Task CreateTicket()
        {
            CreateLastTicketCommand createLastTicketCommand = new()
            { Year = DateTime.Now.Year };
            await _mediator.Send(createLastTicketCommand);
        }
        private async Task UpdateTicket(int lastTicket)
        {
            UpdateLastTicketCommand updateLastTicketCommand = new()
            {
                Year = DateTime.Now.Year,
                LastTicketNumber = lastTicket

            };
            await _mediator.Send(updateLastTicketCommand);
        }


    }
}
