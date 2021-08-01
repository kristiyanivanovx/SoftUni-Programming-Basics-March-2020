using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string index = Console.ReadLine();
            while (!index.Contains("End"))
            {
                int parsed = int.Parse(index);

                if (targets.Count > parsed)
                {
                    int temp = targets[parsed];
                    if (targets[parsed] != -1)
                    {
                        targets[parsed] = -1;

                        for (int i = 0; i < targets.Count; i++)
                        {
                            if (targets[i] > temp && targets[i] != -1)
                            {
                                targets[i] -= temp;
                            }
                            else if (targets[i] <= temp && targets[i] != -1)
                            {
                                targets[i] += temp;
                            }
                        }
                    }
                }

                index = Console.ReadLine();
            }

            int shotCount = targets.Count(x => x == -1);
            Console.WriteLine($"Shot targets: {shotCount} -> {string.Join(" ", targets)}");
        }
    }
}
