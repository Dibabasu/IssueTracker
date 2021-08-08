using IssueTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IssueTracker.Application.Models;

namespace IssueTracker.Application.Features.LastTickets.Query.GetLastTicket
{
    public class GetLastTicketQuery : IRequest<LastTicketDTO>
    {
        public int Year { get; set; }
    }
    public class GetLastTicketQueryHandler : IRequestHandler<GetLastTicketQuery, LastTicketDTO>
    {

        private readonly IApplicationDbContext _context;
        public GetLastTicketQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<LastTicketDTO> Handle(GetLastTicketQuery request, CancellationToken cancellationToken)
        {
            bool YearExists = true;
            var LastTicket = await _context.LastTickets
                .Where(r => r.Year == request.Year).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (LastTicket == null || LastTicket.LastTicketNumber == 0)
            {
                YearExists = false;

            }

            StringBuilder TicketNumberBulider = new();
            TicketNumberBulider.Append(DateTime.Now.Year);

            TicketNumberBulider.Append(string.Format("{0:00000}", LastTicket == null ? 1 : LastTicket.LastTicketNumber + 1));

            return new LastTicketDTO
            {
                LastTicket = TicketNumberBulider.ToString(),
                YearExsists = YearExists,
                LastTicketNumber = LastTicket == null ? 1 : LastTicket.LastTicketNumber,

            };


        }
    }
}
