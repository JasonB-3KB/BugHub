using BugHub.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class BugListItem
    {
        public int BugId { get; set; }
        public string BugTitle { get; set; }

        [Display(Name ="Submitted by")]
        public int  EmployeeId { get; set; }
        public BugStatus BugStatus  { get; set; }
        public BugPriority BugPriority { get; set; }
        public BugType BugType { get; set; }

        [Display(Name="Date Submitted")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
