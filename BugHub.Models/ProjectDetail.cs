using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Models
{
    public class ProjectDetail
    {
        public int ProjectId { get; set; }
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }
        public int EmployeeId { get; set; }
        [Display(Name = "Project Started")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Project Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
