using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Lake lake = new Lake(input);

            List<int> output = new List<int>();
            foreach (int stone in lake)
            {
                output.Add(stone);
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
