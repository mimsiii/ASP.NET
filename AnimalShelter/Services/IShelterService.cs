using AnimalShelter.Data;
using System.Collections.Generic;

namespace AnimalShelter.Services
{
    public interface IShelterService
    {
        void AddAnimal(Animal animalToAdd);

        List<Animal> GetAnimals();

        Animal GetById(int id);

        void EditAnimal(Animal animal);

        void DeleteAnimal(int id);
    }
}
