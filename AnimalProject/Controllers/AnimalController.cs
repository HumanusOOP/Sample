using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AnimalProject.Domain.Models.Interfaces;
using AnimalProject.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAnimals()
        {
            try
            {
                var animals = _animalRepository.GetAllAnimals();
                var animalList = animals?.Where(a => a.Active).ToList() ?? new List<IAnimal>();
                return Ok(animalList);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: " + $"ArgumentException details: {exception.Message}");

                return StatusCode((int) HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: " + $"Exception details: {exception.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            finally
            {
                Console.WriteLine();
            }
        }
    }
}