using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Application.Models
{
    public class LastTicketDTO
    {
        public string LastTicket { get; set; }
        public bool YearExsists { get; set; }
        public int LastTicketNumber { get; set; }
    }
}
