using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.DTO
{
   public class TeamDTO
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public StringBuilder  Name { get; set; }

        public virtual ICollection<ProjectDTO> Projects { get; set; }

        public virtual ICollection<PersonDTO> Persons { get; set; }
    }
}
