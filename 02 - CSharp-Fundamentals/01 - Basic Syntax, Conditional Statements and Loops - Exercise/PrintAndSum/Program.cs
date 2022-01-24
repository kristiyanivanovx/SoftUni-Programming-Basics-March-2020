using System;
using System.Collections.Generic;

namespace PrintAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int current = first; current <= second; current++)
            {
                numbers.Add(current);
                sum += current;
            }

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
