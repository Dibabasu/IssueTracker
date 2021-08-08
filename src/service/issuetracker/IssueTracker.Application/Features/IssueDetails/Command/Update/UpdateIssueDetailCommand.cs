using IssueTracker.Application.Common;
using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Application.Exceptions;
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

namespace IssueTracker.Application.Features.IssueDetails.Command.Update
{
   public class UpdateIssueDetailCommand : IRequest
    {
        public int Id { get; set; }
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
        public string Remark { get; set; }
        public string  UserId { get; set; }
    }
    public class UpdateIssueDetailCommandHandler : IRequestHandler<UpdateIssueDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateIssueDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateIssueDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.IssueDetails.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(IssueDetail), request.Id);
            }
            entity.Catagory = request.Catagory;
            entity.Component = request.Component;
            if (request.CurrentStatus == Constants.ClosedStatus)
            {
                entity.ClosingRemarks = request.Remark;
                entity.ClosedBy = request.UserId;
                entity.ClosedAt = DateTime.UtcNow;
            }
            entity.CurrentStatus = request.CurrentStatus;
            entity.Description = request.Description;
            entity.Priority = (PriorityLevel)Enum.ToObject(typeof(PriorityLevel), request.Priority);
            entity.SubType = request.SubType;
            entity.Summary = request.Summary;
            entity.TicketNumber = request.TicketNumber;
            entity.Type = request.Type;
            entity.UserName = request.UserName;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
