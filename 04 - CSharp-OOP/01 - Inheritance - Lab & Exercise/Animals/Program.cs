using System;
using System.Collections.Generic;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (command != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();

                string animalName = animalInfo[0];
                int animalAge = int.Parse(animalInfo[1]);
                string? animalGender = animalInfo[2];

                Animal animal = null;
                
                if (command == "Cat")
                {
                    animal = new Cat(animalName, animalAge, animalGender);
                }
                else if (command == "Dog")
                {
                    animal = new Dog(animalName, animalAge, animalGender);

                }
                else if (command == "Frog")
                {
                    animal = new Frog(animalName, animalAge, animalGender);
                }
                else if (command == "Kitten")
                {
                    animal = new Kitten(animalName, animalAge);

                }
                else if (command == "Tomcat")
                {
                    animal = new Tomcat(animalName, animalAge);
                }

                animals.Add(animal);
                command = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
