using System.Threading;
using System.Threading.Tasks;
using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Application.Models;
using MediatR;

namespace IssueTracker.Application.Features.IssueDetail.Query.GetIssues
{
    public class GetIssuesWithPaginationQuery : IRequest<PaginatedList<IssuesVM>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetIssuesWithPaginationHandler : IRequestHandler<GetIssuesWithPaginationQuery, PaginatedList<IssuesVM>>
    {
        private readonly IAsyncRepository repo ;
        public Task<PaginatedList<IssuesVM>> Handle(GetIssuesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}