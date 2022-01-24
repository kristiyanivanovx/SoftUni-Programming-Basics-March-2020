using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(number.Count());
            Console.WriteLine(number.Sum());
        }
    }
}
