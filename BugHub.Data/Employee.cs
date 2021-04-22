using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Data
{
    public enum UserRole { Admin, Developer, Tester}
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public UserRole UserRole { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }

    
}
