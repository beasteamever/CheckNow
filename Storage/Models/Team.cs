using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
   public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public StringBuilder  Name { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}
