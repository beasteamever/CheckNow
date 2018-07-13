﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Storage.Models
{
   public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        [Required]
        public IEnumerable<string> ContactInfo { get; set; }        
    }
}
