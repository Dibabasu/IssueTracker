using System.Collections.Generic;

namespace IssueTracker.Application.Models
{
    public class IssuesVM
    {
        public IList<PriorityLevelDto> PriorityLevels { get; set; }
        public IList<IssueDetailDto> Lists { get; set; }
    }
}