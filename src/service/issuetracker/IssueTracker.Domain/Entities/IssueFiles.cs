using IssueTracker.Domain.Common;

namespace IssueTracker.Domain.Entities
{
    public class IssueFileUpload : EntityBase
    {
        public IssueDetail IssueDetail { get; set; }
        public int IssueDetailId { get; set; }
        public string TicketNumber { get; set; }
        public string StoreFileName { get; set; }
        public string UploadedFileName { get; set; }
        public string FileExtention { get; set; }

    }
}