using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Application.Models;
using IssueTracker.Domain.Entities;
using IssueTracker.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.IssueDetails.Command.Create
{
    public class CreateIssueDetailCommand : IRequest<int>
    {
        public string TicketNumber { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public string UserName { get; set; }
        public string Component { get; set; }
        public string Catagory { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
    }

    public class CreateIssueDetailHandler : IRequestHandler<CreateIssueDetailCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateIssueDetailHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateIssueDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = new IssueDetail
            {
                Catagory = request.Catagory,
                Component = request.Component,
                CurrentStatus = request.CurrentStatus,
                Description = request.Description,
                Priority = (PriorityLevel)Enum.ToObject(typeof(PriorityLevel), request.Priority),
                SubType = request.SubType,
                Summary = request.Summary,
                TicketNumber = request.TicketNumber,
                Type = request.Type,
                UserName = request.UserName
            };

            _context.IssueDetails.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
