using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            SortedSet<string> hashsetChemicals = new SortedSet<string>();

            for (int i = 0; i < elementsCount; i++)
            {
                string[] chemicals = Console.ReadLine().Split();

                foreach (var chemElement in chemicals)
                {
                    hashsetChemicals.Add(chemElement);
                }
            }

            Console.WriteLine(string.Join(" ", hashsetChemicals));
        }
    }
}
