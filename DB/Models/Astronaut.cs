using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DB.Models
{
    [Table("Astronaut")]
    public class Astronaut
    {
        [Required, Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100), StringLength(110)]
        public string Name { get; set; }
        [Required, MaxLength(100), StringLength(110)]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(100), StringLength(110)]
        public string Superpower { get; set; }
    }
}
