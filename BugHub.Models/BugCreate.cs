using BugHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class BugCreate
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string BugTitle { get; set; }
        public string BugDescription { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        public BugStatus BugStatus { get; set; }
        [Required]
        public BugPriority BugPriority { get; set; }
        [Required]
        public BugType BugType { get; set; }
        
    }
}
