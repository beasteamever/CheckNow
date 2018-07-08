using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    class Team
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(4), MaxLength(30)]
        public string Name { get; set; }

        public List<string> Projects { get; set; }
        public Project Project { get; set; }

        public List<string> Persons { get; set; }
        public Person Person { get; set; }      
    }
}
