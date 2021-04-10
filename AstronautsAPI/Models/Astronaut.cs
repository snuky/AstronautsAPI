using System;

namespace AstronautsAPI.Models
{
    public class Astronaut
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Superpower { get; set; }
    }
}