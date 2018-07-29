using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Storage.Models
{
   public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        [Required]
        public StringBuilder  Name { get; set; }
        public StringBuilder  Info { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public virtual ICollection<Task> TaskId { get; set; }
    }
}
