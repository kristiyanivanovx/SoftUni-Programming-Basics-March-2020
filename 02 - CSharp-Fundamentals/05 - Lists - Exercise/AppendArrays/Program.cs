using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split("|").ToList();
            List<int> output = new List<int>();

            for (int i = input.Count - 1; i >= 0; i--)
            {
                int[] current = input[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                output.AddRange(current);
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}
