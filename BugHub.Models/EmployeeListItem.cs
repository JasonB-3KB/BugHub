using BugHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class EmployeeListItem
    {
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name="Date Employee was Added")]
        public DateTimeOffset CreatedUtc { get; set; }
        
    }
}
