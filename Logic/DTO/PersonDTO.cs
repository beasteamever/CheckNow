using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Logic.DTO
{
    public class PersonDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }

        public string TeamName { get; set; }
        public TeamDTO Team { get; set; }

        public virtual IEnumerable<TaskDTO> Tasks { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public string Login { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        // public enum role {get;set}

    }
}
