using System;
using System.Collections.Generic;
using System.Linq;

namespace Pirates
{
    public class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            List<City> cities = new List<City>();

            while (command != "Sail")
            {
                var data = command.Split("||");
                var name = data[0];
                var population = int.Parse(data[1]);
                var gold = int.Parse(data[2]);

                bool isCityContained = cities.Any(x => x.Name == name);
                if (isCityContained)
                {
                    var city = cities.FirstOrDefault(x => x.Name == name);
                    city.Population += population;
                    city.Gold += gold;
                }
                else
                {
                    var city = new City(name, population, gold);
                    cities.Add(city);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (!command.Contains("End"))
            {
                var data = command.Split("=>");
                string eventType = data[0];
                string eventTown = data[1];

                if (eventType == "Plunder")
                {
                    int eventPeople = int.Parse(data[2]);
                    int eventGold = int.Parse(data[3]);

                    var city = cities.FirstOrDefault(x => x.Name == eventTown);
                    city.Population -= eventPeople;
                    city.Gold -= eventGold;

                    Console.WriteLine($"{eventTown} plundered! {eventGold} gold stolen, {eventPeople} citizens killed.");
                    if (city.Population <= 0 || city.Gold <= 0)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{eventTown} has been wiped off the map!");
                    }

                }
                else if (eventType == "Prosper")
                {
                    int eventGold = int.Parse(data[2]);
                    var city = cities.FirstOrDefault(x => x.Name == eventTown);

                    if (eventGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        city.Gold += eventGold;
                        Console.WriteLine($"{eventGold} gold added to the city treasury. {city.Name} now has {city.Gold} gold.");
                    }
                }

                command = Console.ReadLine();
            }

            if (cities.Any())
            {
                cities = cities.OrderByDescending(x => x.Gold).ThenBy(x => x.Name).ToList();
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                cities.ForEach(c => Console.WriteLine($"{c.Name} -> Population: {c.Population} citizens, Gold: {c.Gold} kg"));
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
