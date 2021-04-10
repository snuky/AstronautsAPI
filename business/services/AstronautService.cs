using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace business.services
{
    public class AstronautService

    {
        private readonly AstronautContext _context;

        public AstronautService(AstronautContext context)
        {
            _context = context;

        }

        public IEnumerable<Astronaut> GetAllAstronauts()
        {
            return _context.Astronaut.ToList();
        }

        public Astronaut GetAstronautById(Guid id)
        {
            return _context.Astronaut.Find(id);
        }

        public bool CreateAstronaut(string name, string surname, DateTime dateOfBirth, string superpower)
        {
            if (dateOfBirth > DateTime.Now)
            {
                return false;
            }
            var astronaut = new Astronaut { Name = name, Surname = surname, DateOfBirth = dateOfBirth, Superpower = superpower };

            _context.Astronaut.Add(astronaut);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;

        }


        public bool UpdateAstronaut(Guid id, string name, string surname, DateTime dateOfBirth, string superpower)
        {
            if (dateOfBirth > DateTime.Now)
            {
                return false;
            }

            var astronaut = new Astronaut { Id = id, Name = name, Surname = surname, DateOfBirth = dateOfBirth, Superpower = superpower };
            _context.Entry(astronaut).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }

            return true;
        }

        public bool DeleteAstronaut(Guid id)
        {
            var astronaut = _context.Astronaut.Find(id);
            if (astronaut == null)
            {
                return false;
            }

            _context.Astronaut.Remove(astronaut);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
