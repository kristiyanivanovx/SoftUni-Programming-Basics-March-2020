using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdAstra
{
    class Item
    {
        public Item(string name, string bestBefore, int calories)
        {
            this.Name = name;
            this.BestBefore = bestBefore;
            this.Calories = calories;
        }

        public string Name { get; set; }

        public string BestBefore { get; set; }

        public int Calories { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();

            string pattern = @"(\||\#)[A-Za-z0-9 ]{1,}\1[0-9]{2}\/[0-9]{2}\/[0-9]{2}\1([0-9]{1,4}|10000)\1";
            string input = Console.ReadLine();
            char[] splitters = new char[] { '#', '|' };
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string[] data = match.Value.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                var item = new Item(data[0], data[1], int.Parse(data[2]));
                items.Add(item);
            }

            int days = items.Sum(x => x.Calories) / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            items.ForEach(x => Console.WriteLine($"Item: {x.Name}, Best before: {x.BestBefore}, Nutrition: {x.Calories}"));
        }
    }
}