﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
   public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        public string State { get; set; }
        public int Priority { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEndings { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        public string Info { get; set; }
        [ForeignKey("Person")]
        public string projectManager { get; set; }
        public Person Person { get; set; }
        [ForeignKey("Customer")]
        public string CustomerName { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Team")]
        public string TeamName { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<Feature> FeatureId { get; set; }
    }
}
