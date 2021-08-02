using System;
using System.Collections.Generic;
using System.Linq;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string element = Console.ReadLine();
            while (!element.Contains("End"))
            {
                var data = element.Split();
                var type = data[0];
                var index = int.Parse(data[1]);

                if (type == "Shoot")
                {
                    var power = int.Parse(data[2]);

                    if (targets.Count > index && index >= 0)
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (type == "Add")
                {
                    var value = int.Parse(data[2]);

                    if (targets.Count > index && index >= 0)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid placement!");
                    }
                }
                else if (type == "Strike")
                {
                    var radius = int.Parse(data[2]);

                    if (index + radius < targets[targets.Count - 1] && index - radius >= 0)
                    {
                        targets.RemoveRange(index - radius, radius * 2 + 1);
                    }
                    else
                    {
                        Console.WriteLine($"Strike missed!");
                    }
                }

                element = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
