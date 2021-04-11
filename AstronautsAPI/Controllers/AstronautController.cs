using AstronautsAPI.Models;
using business.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AstronautsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AstronautController : ControllerBase
    {
        private readonly AstronautService _astronautService;

        public AstronautController(AstronautService astronautService)
        {
            _astronautService = astronautService;
        }

        /// <summary>
        /// Returns astronaut by its id
        /// </summary>
        /// <param name="reservationId">Specific astronaut id</param>
        /// <response code="200">search results matching criteria</response>
        /// <response code="500">Server error</response>
        [HttpGet("{id}")]
        public ActionResult<Astronaut> GetAstronaut(Guid id)
        {
            var astronaut = _astronautService.GetAstronautById(id);

            if (astronaut == null)
            {
                return StatusCode(404);
            }

            var result = new Astronaut()
            {
                Id = astronaut.Id,
                Name = astronaut.Name,
                Surname = astronaut.Surname,
                DateOfBirth = astronaut.DateOfBirth,
                Superpower = astronaut.Superpower
            };

            return result;
        }

        /// <summary>
        /// Returns a list of all astronauts
        /// </summary>
        /// <response code="200">search results matching criteria</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        public IEnumerable<Astronaut> GetAstronauts()
        {
            var astronauts = _astronautService.GetAllAstronauts();

            var result = astronauts.Select(a => new Astronaut()
            {
                Id = a.Id,
                Name = a.Name,
                Surname = a.Surname,
                DateOfBirth = a.DateOfBirth,
                Superpower = a.Superpower
            });

            return result.ToList();
        }

        /// <summary>
        /// Create new astronaut
        /// </summary>
        /// <response code="200">new astronaut is created</response>
        /// <response code="422">astronaut is in incorrect format</response>
        /// <response code="500">server errror</response>
        [HttpPost]
        public IActionResult Create(Astronaut astronaut)
        {
            var isCreated = _astronautService.CreateAstronaut(astronaut.Name, astronaut.Surname, astronaut.DateOfBirth, astronaut.Superpower);
            if (isCreated)
            {
                return StatusCode(200);
            }
            else return StatusCode(422);
        }

        /// <summary>
        /// Update existing astronaut
        /// </summary>
        /// <param name="id">Specific astronaut id</param>
        /// <response code="200">given astrnonaut was updated</response>
        /// <response code="422">astrnonaut was not found with given id</response>
        /// <response code="500">server error</response>
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Astronaut astronaut)
        {
            if (id != astronaut.Id)
            {
                return BadRequest();
            }
            var isUpdated = _astronautService.UpdateAstronaut(id, astronaut.Name, astronaut.Surname, astronaut.DateOfBirth, astronaut.Superpower);

            if (isUpdated)
            {
                return StatusCode(200);
            }

            return StatusCode(422);
        }

        /// <summary>
        /// detele specific astronaut
        /// </summary>
        /// <param name="id">Specific astronaut  id</param>
        /// <response code="200">astronaut was sucessfuly deleted</response>
        /// <response code="422">there is no existing astronaut with given id</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var isDeleted = _astronautService.DeleteAstronaut(id);

            if (isDeleted)
            {
                return StatusCode(200);
            }

            return StatusCode(422);
        }
    }
}
