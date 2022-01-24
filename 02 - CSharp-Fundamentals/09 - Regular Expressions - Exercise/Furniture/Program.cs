using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furniture = new List<string>();
            
            double total = 0d;
            string pattern = @"(>>)[A-Za-z]{1,}(<<)[0-9]{1,}.{0,1}[0-9]{1,}![0-9]{1,}";
            string[] splitters = new string[] { ">>", "<<", "!" };
            
            string command = Console.ReadLine();

            while (!command.Contains("Purchase"))
            {
                Match match = Regex.Match(command, pattern);
                if (match.Captures.Count > 0)
                {
                    string[] splitted = match.Value.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                    furniture.Add(splitted[0]);
                    total += double.Parse(splitted[1]) * double.Parse(splitted[2]);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Bought furniture:");
            furniture.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Total money spend: {total:f2}");
        }
    }
}
