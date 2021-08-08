using IssueTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Contracts.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<IssueDetail> IssueDetails { get;  set; }
        DbSet<IssueFileUpload> IssueFileUploads { get;  set; }

        DbSet<IssueHistory> IssueHistories { get; set; }
        DbSet<LastTicket> LastTickets { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
