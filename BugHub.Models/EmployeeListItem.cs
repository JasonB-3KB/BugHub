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
        [Display(Name ="Employee Email")]
        public string EmployeeEmail { get; set; }
        [Display(Name ="Access Level")]
        public EmployeeRole EmployeeRole { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public int ProjectId { get; set; }

        [Display(Name="Date Employee was Added")]
        public DateTimeOffset CreatedUtc { get; set; }
        
    }
}
