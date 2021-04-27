using BugHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class EmployeeCreate
    {
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
        [Required]
        public EmployeeRole EmployeeRole { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
