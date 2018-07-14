using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.DTO
{
    public class FeatureDTO
    {
        [Key]
        public int FeatureId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
        public virtual ICollection<TaskDTO> TaskId { get; set; }
    }
}
