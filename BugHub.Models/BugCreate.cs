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
    public enum BugStatus { Open, In_Progress, Closed }
    public enum BugPriority { High, Medium, Low }
    public enum BugType { Bug_Error, Feature_Request, Training_Request }
    public class BugCreate
    {
        [Required]
        public string BugTitle { get; set; }
        public string BugDescription { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public BugStatus BugStatus { get; set; }
        public BugPriority BugPriority { get; set; }
        public BugType BugType { get; set; }
        
    }
}
