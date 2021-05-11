using BugHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class EmployeeEdit
    {
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ProjectId { get; set; }
        
    }
}
