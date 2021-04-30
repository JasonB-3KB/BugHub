using BugHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Employee Added")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Employee Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
