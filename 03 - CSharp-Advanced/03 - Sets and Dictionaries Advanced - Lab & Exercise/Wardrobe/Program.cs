using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothInput = Console.ReadLine().Split(" -> ");

                string color = clothInput[0]; 
                string[] variantsOfClothes = clothInput[1].Split(',');

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var currCloth in variantsOfClothes)
                {
                    if (!wardrobe[color].ContainsKey(currCloth))
                    {
                        wardrobe[color].Add(currCloth, 1);
                    }
                    else
                    {
                        wardrobe[color][currCloth] += 1;
                    }
                }
            }

            string[] toBeSearched = Console.ReadLine().Split();

            string colorTBS = toBeSearched[0];
            string clothTypeTBS = toBeSearched[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine(item.Key + " clothes:");

                foreach (var i in item.Value)
                {
                    Console.Write("* " + i.Key + " - " + i.Value);

                    if (item.Key == colorTBS && i.Key == clothTypeTBS)
                    {
                        Console.Write(" (found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
