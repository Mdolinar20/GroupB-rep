using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupB_Project.Models
{
    public class ScheduledSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Subject { get; set; }
    }
}
