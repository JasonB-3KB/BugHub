using BugHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class BugEdit
    {
        public int BugId { get; set; }
        public string BugTitle { get; set; }
        public string BugDescription { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public BugStatus BugStatus { get; set; }
        
        public BugPriority BugPriority { get; set; }
        
        public BugType BugType { get; set; }
    }
}
