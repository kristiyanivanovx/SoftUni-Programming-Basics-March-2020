using System;
using System.Collections.Generic;
using System.Linq;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            int count = 1;
            string previous = null;
            string command = Console.ReadLine();
            while (!command.Contains("stop"))
            {
                bool isEven = count % 2 == 0;
                var isNumeric = int.TryParse(command, out _);
                
                if (!isNumeric)
                {
                    previous = command;
                }
                
                if (!isEven)
                {
                    if (!materials.ContainsKey(command))
                    {
                        materials.Add(command, 0);
                    }
                }
                else
                {
                    int quantity = int.Parse(command);
                    materials[previous] += quantity; 
                }

                count++;
                command = Console.ReadLine();
            }

            materials.ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value}"));
        }
    }
}
