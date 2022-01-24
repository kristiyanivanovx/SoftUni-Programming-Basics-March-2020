using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] acceptableMaterials = new string[3] { "shards", "fragments", "motes" };
            
            Dictionary<string, int> materials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            Dictionary<string, string> legendaries = new Dictionary<string, string>()
            {
                { "shards", "Shadowmourne"},
                { "fragments", "Valanyr"},
                { "motes", "Dragonwrath"},
            };

            materials.Add("fragments", 0);
            materials.Add("motes", 0);
            materials.Add("shards", 0);

            string command = Console.ReadLine();
            while (materials["motes"] < 250 && materials["shards"] < 250 && materials["fragments"] < 250)
            {
                string[] data = command.Split(" ");
                for (int i = 0; i < data.Length; i++)
                {
                    bool isNumeric = int.TryParse(data[i], out _);
                    if (isNumeric)
                    {
                        int quantity = int.Parse(data[i]);
                        string item = data[i + 1].ToLower();

                        if (acceptableMaterials.Contains(item))
                        {
                            materials[item] += quantity;
                        }
                        else
                        {
                            if (!junk.ContainsKey(item))
                            {
                                junk.Add(item, quantity);
                            }
                            else
                            {
                                junk[item] += quantity;
                            }
                        }
                    }

                    if (materials["shards"] >= 250 || materials["fragments"] >= 250 || materials["motes"] >= 250)
                    {
                        break;
                    }
                }

                command = Console.ReadLine();
                if (command == "")
                {
                    break;
                }
            }

            string material = null;
            if (materials.Any(x => x.Value >= 250))
            {
                material = CheckForLegendary(materials);
            }

            if (material != null)
            {
                Console.WriteLine(legendaries[material] + " obtained!");
            }

            materials = materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            materials.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
            junk = junk.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            junk.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
        }

        private static string CheckForLegendary(Dictionary<string, int> materials)
        {
            var material = materials.FirstOrDefault(x => x.Value >= 250);
            materials[material.Key] -= 250;
            return material.Key;
        }
    }
}

