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
    public class ProjectCreate
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string ProjectName { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
