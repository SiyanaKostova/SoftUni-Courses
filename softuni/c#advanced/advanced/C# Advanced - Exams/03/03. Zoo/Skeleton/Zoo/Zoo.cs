using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }
        public int Count { get { return Animals.Count; } }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Capacity == Animals.Count)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int countOfRemovedAnimals = 0;

            while (Animals.FirstOrDefault(a => a.Species == species) != null)
            {
                var targetAnimal = Animals.FirstOrDefault(a => a.Species == species);
                Animals.Remove(targetAnimal);
                countOfRemovedAnimals++;
            }

            return countOfRemovedAnimals;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animals = new List<Animal>();

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Diet == diet)
                {
                    animals.Add(Animals[i]);
                }
            }

            return animals;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            Animal animal;
            animal = Animals.FirstOrDefault(a => a.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int countOfAnimals = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Length <= maximumLength && Animals[i].Length >= minimumLength)
                {
                    countOfAnimals++;
                }
            }

            return $"There are {countOfAnimals} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
