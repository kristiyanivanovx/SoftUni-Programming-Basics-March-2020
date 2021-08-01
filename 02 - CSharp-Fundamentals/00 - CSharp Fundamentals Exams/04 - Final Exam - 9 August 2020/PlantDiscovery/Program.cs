using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
        }

        public string Name { get; set; }

        public int Rarity { get; set; }

        public double Rating { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var entry = Console.ReadLine();
                var data = entry.Split("<->");
                string name = data[0];
                int rarity = int.Parse(data[1]);

                Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);
                if (existingPlant != null)
                {
                    existingPlant.Rarity = rarity;
                }
                else if (existingPlant == null)
                {
                    var plant = new Plant(name, rarity);
                    plants.Add(plant);
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            var command = Console.ReadLine();
            while (!command.Contains("Exhibition"))
            {
                var splitters = new string[] { ": ", " - " };
                var data = command.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                var type = data[0];
                var name = data[1];

                if (type == "Rate")
                {
                    var rating = int.Parse(data[2]);

                    Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);
                    if (existingPlant != null)
                    {
                        if (existingPlant.Rating == 0)
                        {
                            existingPlant.Rating += rating;
                        }
                        else
                        {
                            existingPlant.Rating = (existingPlant.Rating + rating) / 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                if (type == "Update")
                {
                    var newRarity = int.Parse(data[2]);
                    Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);
                    if (existingPlant != null)
                    {
                        existingPlant.Rarity = newRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                if (type == "Reset")
                {
                    Plant existingPlant = plants.FirstOrDefault(x => x.Name == name);
                    if (existingPlant != null)
                    {
                        existingPlant.Rating = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Plants for the exhibition:");

            plants = plants.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.Rating).ToList();
            plants.ForEach(x => Console.WriteLine($"- {x.Name}; Rarity: {x.Rarity}; Rating: {x.Rating:f2}"));
        }
    }
}
