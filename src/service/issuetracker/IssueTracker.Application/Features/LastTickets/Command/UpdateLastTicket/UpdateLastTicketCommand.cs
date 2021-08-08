using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Application.Exceptions;
using IssueTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.LastTickets.Command.UpdateLastTicket
{
    public class UpdateLastTicketCommand : IRequest
    {
        public int LastTicketNumber { get; set; }
        public int Year { get; set; }
    }
    public class UpdateLastTicketHandler : IRequestHandler<UpdateLastTicketCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLastTicketHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateLastTicketCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.LastTickets.Where(r => r.Year == request.Year).FirstOrDefault();
            if (entity == null)
            {
                throw new NotFoundException(nameof(LastTicket), request.Year);
            }

            entity.LastTicketNumber = request.LastTicketNumber + 1;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
