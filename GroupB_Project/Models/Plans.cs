using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupB_Project.Models
{
    public class Plans
    {
        [Key]
        public int planId { get; set; }
        public int hours { get; set; }
        public string subject { get; set; }
    }
}
