using IssueTracker.Domain.Common;

namespace IssueTracker.Application.Models
{
    public class IssueDetailDto : EntityBase
    {
        public string TicketNumber { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public string UserName { get; set; }
        public string Component { get; set; }
        public string Catagory { get; set; }
        public PriorityLevelDto Priority { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
    }
}