using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4, 2, 1, 3, 5, 7, 1, 4, 2, 12
            // 10
            // 41

            int[] number = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(number.Count());
            Console.WriteLine(number.Sum());
        }
    }
}
