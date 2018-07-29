using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic.DTO
{
    public class FeatureDTO
    {
        [Key]
        public int FeatureId { get; set; }
        [Required]
        public StringBuilder  Name { get; set; }
        public StringBuilder  Info { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
        public virtual ICollection<TaskDTO> TaskId { get; set; }
    }
}
