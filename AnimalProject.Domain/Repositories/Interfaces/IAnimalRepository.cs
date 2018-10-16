using System.Collections.Generic;
using AnimalProject.Domain.Models.Interfaces;

namespace AnimalProject.Domain.Repositories.Interfaces
{
    public interface IAnimalRepository
    {
        List<IAnimal> GetAllAnimals();
    }
}