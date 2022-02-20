using System;
namespace AnimalShelter.Data
{
    public class Animal
    {
        public int Id { get; set; }

        public string AnimalKind { get; set; }

        public string YesNoBreed { get; set; }

        public DateTime BringDate { get; set; }
    }
}
