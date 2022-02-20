using AnimalShelter.Data;
using AnimalShelter.DataAccess;
using AnimalShelter.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Services
{
    public class ShelterService : IShelterService
    {
        private readonly ApplicationDbContext db;

        public ShelterService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddAnimal(Animal AnimalToAdd)
        {
            db.Animals.Add(AnimalToAdd);
            db.SaveChanges();
        }

        public void DeleteAnimal(int id)
        {
            var animalToBeDeleted = this.GetById(id);
            this.db.Animals.Remove(animalToBeDeleted);
            db.SaveChanges();
        }

        public void EditAnimal(Animal animalToEdit)
        {
            var animal = this.GetById(animalToEdit.Id);

            animal.AnimalKind = animalToEdit.AnimalKind;
            animal.YesNoBreed = animalToEdit.YesNoBreed;
            animal.BringDate = animalToEdit.BringDate;

            db.SaveChanges();
        }

        public List<Animal> GetAnimals()
        {
            return db.Animals.ToList();
        }

        public Animal GetById(int id)
        {
            return this.db.Animals.FirstOrDefault(x => x.Id == id);
        }
    }
}
