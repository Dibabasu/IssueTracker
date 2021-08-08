using FluentValidation;
using IssueTracker.Application.Features.IssueDetails.Command.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Application.Featuress.Command.Create
{
    class CreateIsseuDetailCommandValidator :AbstractValidator<CreateIssueDetailCommand>
    {
        public CreateIsseuDetailCommandValidator()
        {
            RuleFor(v => v.CurrentStatus)
                .NotEmpty();

            RuleFor(v => v.Component)
                .NotEmpty();

            RuleFor(v => v.Type)
                .NotEmpty();

            RuleFor(v => v.UserName)
                .NotEmpty();

            RuleFor(v => v.TicketNumber)
                .NotEmpty();

            RuleFor(v => v.SubType)
                .NotEmpty();

            RuleFor(v => v.Catagory)
                .NotEmpty();

            RuleFor(v => v.Priority)
                .NotEmpty();

            RuleFor(v => v.Description)
                .NotEmpty();

            RuleFor(v => v.Summary)
                .NotEmpty()
                .MaximumLength(250);

        }
    }
}
