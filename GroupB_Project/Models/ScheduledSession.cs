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
        [Key]
        public int sessionId { get; set; }
        public DateTime sessionDate { get; set; }
        public string subject { get; set; }
        [DisplayName("Desired Time")]
        public int desiredTime { get; set; }

    }
}
