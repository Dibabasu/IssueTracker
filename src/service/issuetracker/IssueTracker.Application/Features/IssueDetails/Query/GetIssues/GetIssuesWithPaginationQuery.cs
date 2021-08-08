using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IssueTracker.Application.Contracts.Persistence;
using IssueTracker.Application.Models;
using MediatR;
using AutoMapper.QueryableExtensions;
using System.Linq;
using IssueTracker.Application.Common.Mapping;
using System.Linq.Expressions;
using System;
using IssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IssueTracker.Application.Features.IssueDetails.Query.GetIssues
{
    public class GetIssuesWithPaginationQuery : IRequest<PaginatedList<IssueDetail>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetIssuesWithPaginationHandler : IRequestHandler<GetIssuesWithPaginationQuery, PaginatedList<IssueDetail>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetIssuesWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<IssueDetail>> Handle(GetIssuesWithPaginationQuery request, CancellationToken cancellationToken)
        {

            return await _context.IssueDetails
                .Where(r => true)
                .OrderBy(r => r.Created)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;




        }
    }
}