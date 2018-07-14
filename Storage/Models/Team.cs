using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
   public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
