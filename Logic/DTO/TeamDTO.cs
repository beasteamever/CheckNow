using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO
{
   public class TeamDTO
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public string Name { get; set; }

        public virtual IEnumerable<ProjectDTO> Projects { get; set; }

        public virtual IEnumerable<PersonDTO> Persons { get; set; }
    }
}
