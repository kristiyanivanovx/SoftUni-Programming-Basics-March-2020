using System;

using WildFarm.Models;
using WildFarm.Models.Foods;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

using WildFarm.Animals;
using WildFarm.Core.Interfaces;
using WildFarm.Models.Animals.Interfaces;
using System.Collections.Generic;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run() 
        {
            List<Animal> animals = new List<Animal>();
            string[] animalArguments = Console.ReadLine().Split();
            string type = animalArguments[0];

            while (type != "End")
            {
                string name = animalArguments[1];
                double weight = double.Parse(animalArguments[2]);
                Animal animal = CreateAnimal(animalArguments, type, name, weight);

                string[] foodArguments = Console.ReadLine().Split();
                Food food = CreateFood(foodArguments);

                Console.WriteLine(animal.MakeNoice());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                animals.Add(animal);
                animalArguments = Console.ReadLine().Split();
                type = animalArguments[0];
            }

            animals.ForEach(x => Console.WriteLine(x.ToString()));
        }

        private static Animal CreateAnimal(string[] animalArguments, string type, string name, double weight)
        {
            Animal animal = null;
            if (type == "Cat")
            {
                animal = new Cat(name, weight, animalArguments[3], animalArguments[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, animalArguments[3], animalArguments[4]);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, animalArguments[3]);
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, animalArguments[3]);
            }
            else if (type == "Owl")
            {
                double wingSize = double.Parse(animalArguments[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(animalArguments[3]);
                animal = new Owl(name, weight, wingSize);
            }

            return animal;
        }

        private static Food CreateFood(string[] foodArguments)
        {
            Food food = null;
            string type = foodArguments[0];

            if (type == "Vegetable")
            {
                food = new Vegetable(int.Parse(foodArguments[1]));
            }
            else if (type == "Fruit")
            {
                food = new Fruit(int.Parse(foodArguments[1]));
            }
            else if (type == "Meat")
            {
                food = new Meat(int.Parse(foodArguments[1]));
            }
            
            return food;
        }
    }
}
