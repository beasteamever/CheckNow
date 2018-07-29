using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logic.DTO
{
    public class TaskDTO
    {
        [Key]
        public int TaskId { get; set; }
        public StringBuilder  Name { get; set; }
        public StringBuilder  State { get; set; }
        public StringBuilder  Code { get; set; }
        public StringBuilder  Info { get; set; }
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public FeatureDTO Feature { get; set; }
        public DateTime DateTime { get; set; }

        public StringBuilder  PersonName { get; set; }
        public PersonDTO Person { get; set; }
    }
}
