using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.DTO
{
    public class TaskDTO
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
        public string Info { get; set; }
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public FeatureDTO Feature { get; set; }
        public DateTime DateTime { get; set; }

        public string PersonName { get; set; }
        public PersonDTO Person { get; set; }
    }
}
