using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Data
{
    public enum EmployeeRole { Admin, Developer, Tester}
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
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
        [Required]
        public int ProjectId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

    
}
