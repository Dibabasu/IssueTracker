using System;
using System.Collections.Generic;
using IssueTracker.Domain.Common;
using IssueTracker.Domain.Enums;

namespace IssueTracker.Domain.Entities
{
    public class IssueDetail : EntityBase
    {
        public string TicketNumber { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string CurrentStatus { get; set; }
        public string UserName { get; set; }
        public string Component { get; set; }
        public string Catagory { get; set; }
        public PriorityLevel Priority { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string ClosedBy { get; set; }
        public string ClosingRemarks { get; set; }

        public IList<IssueHistory> History { get; private set; } = new List<IssueHistory>();

        public IList<IssueFileUpload> FileUpload { get; private set; } = new List<IssueFileUpload>();


    }
}