using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Storage.Models
{
   public class Project
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
        public Person Person { get; set; }
        [ForeignKey("Customer")]
        public StringBuilder  CustomerName { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Team")]
        public StringBuilder  TeamName { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<Feature> FeatureId { get; set; }
    }
}
