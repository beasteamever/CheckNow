using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.DTO
{
    public class CustomerDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public StringBuilder Name { get; set; }
        public StringBuilder Country { get; set; }
        [Required]
        public IEnumerable<StringBuilder> ContactInfo { get; set; }
    }
}
