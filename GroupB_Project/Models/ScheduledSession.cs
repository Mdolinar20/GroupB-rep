using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupB_Project.Models
{
    public class ScheduledSession
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Session Starting Time")]
        public DateTime ScheduledDateStart { get; set; }
        public DateTime ScheduleDateEnd { get; set; }
        [DisplayName ("Session Study Subject")]
        public string Subject { get; set; }
        [DisplayName("Study Location")]
        public string Location { get; set; }
    }
}
