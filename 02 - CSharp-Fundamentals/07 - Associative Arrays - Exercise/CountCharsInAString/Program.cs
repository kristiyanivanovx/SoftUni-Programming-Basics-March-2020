using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            string input = Console.ReadLine();
            char[] characters = input.ToCharArray().Where(x => x != ' ').ToArray();

            characters.ToList().ForEach(x =>
            {
                if (counter.ContainsKey(x))
                {
                    counter[x]++;
                }
                else
                {
                    counter.Add(x, 1);
                }
            });

            counter.ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value}"));
        }
    }
}
