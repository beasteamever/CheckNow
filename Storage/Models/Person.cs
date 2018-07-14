using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Storage.Models
{
   public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }

        public string TeamName { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public string Login { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        // public enum role {get;set}

    }
}
