using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic.DTO
{
    public class ProjectDTO
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public StringBuilder  Name { get; set; }
        public StringBuilder  State { get; set; }
        public int Priority { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEndings { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        public StringBuilder  Info { get; set; }
        [ForeignKey("Person")]
        public StringBuilder  projectManager { get; set; }
        public PersonDTO Person { get; set; }
        [ForeignKey("Customer")]
        public StringBuilder  CustomerName { get; set; }
        public CustomerDTO Customer { get; set; }
        [ForeignKey("Team")]
        public StringBuilder  TeamName { get; set; }
        public TeamDTO Team { get; set; }

        public virtual ICollection<FeatureDTO> FeatureId { get; set; }

    }
}
