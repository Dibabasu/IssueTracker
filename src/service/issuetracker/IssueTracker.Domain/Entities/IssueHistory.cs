using IssueTracker.Domain.Common;

namespace IssueTracker.Domain.Entities
{
    public class IssueHistory : EntityBase
    {
        public string TicketNumber { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

        public IssueDetail IssueDetail { get; set; }

        public int IssueDetailId { get; set; }
    }
}