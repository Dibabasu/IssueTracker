using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.LastTickets.Command.CreateLastTicket
{
    public class CreateLastTicketCommand : IRequest<int>
    {
        public int Year { get; set; }
    }
    public class CreateLastTicketHandler : IRequestHandler<CreateLastTicketCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateLastTicketHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateLastTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = new LastTicket
            {
                Year = request.Year,
                LastTicketNumber = 1

            };

            _context.LastTickets.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
