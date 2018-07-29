using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Storage.Models
{
   public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public StringBuilder  Name { get; set; }
        public StringBuilder  Mail { get; set; }
        public StringBuilder  Phone { get; set; }
        public StringBuilder Picture { get; set; }

        public StringBuilder  TeamName { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public StringBuilder  Login { get; set; }
        [Required, MinLength(4), MaxLength(16)]
        public StringBuilder  Password { get; set; }

        // public enum role {get;set}

    }
}
