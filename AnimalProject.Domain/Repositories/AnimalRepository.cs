using System;
using System.Collections.Generic;
using System.Linq;
using AnimalProject.Domain.Models;
using AnimalProject.Domain.Models.Interfaces;
using AnimalProject.Domain.Repositories.Interfaces;

namespace AnimalProject.Domain.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        public List<IAnimal> GetAllAnimals()
        {
            using (var db = new Db())
            {
                var animals = db.Animals.ToList();
                return animals;
            }
        }
    }

    public class Db : IDisposable
    {
        public List<IAnimal> Animals => new List<IAnimal>
        {
            new Cat { Age = 5, Name = "Trasan" },
            new Giraffe { Age = 8, Name = "Långben" },
            new Sparrow { Name = "Fjäder" }
        };

        public void Dispose()
        {
            Console.WriteLine("Disposing");
        }
    }
}
