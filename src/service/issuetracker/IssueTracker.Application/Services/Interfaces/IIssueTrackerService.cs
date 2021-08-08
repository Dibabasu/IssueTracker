using IssueTracker.Application.Features.IssueDetails.Command.Create;
using IssueTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Application.Services
{
    public interface IIssueTrackerService
    {
        Task<int> CreateIssueDetailsAsync(CreateIssueDetailCommand command);

       // Task<List<IssueDetail>> FetchIssueDetails();
    }
}
