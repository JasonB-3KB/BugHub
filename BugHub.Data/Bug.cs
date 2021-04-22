using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugHub.Data
{
    public enum BugStatus { Open, In_Progress, Closed }
    public enum BugPriority { High, Medium, Low }
    public enum BugType { Bug_Error, Feature_Request, Training_Request}
    public class Bug
    {
        [Key]
        public int BugId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string BugTitle { get; set; }
        [Required]
        public string BugDescription { get; set; }

        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }        

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Required]
        public BugStatus BugStatus { get; set; }
        [Required]
        public BugPriority BugPriority { get; set; }
        [Required]
        public BugType BugType { get; set; }


    }
}
