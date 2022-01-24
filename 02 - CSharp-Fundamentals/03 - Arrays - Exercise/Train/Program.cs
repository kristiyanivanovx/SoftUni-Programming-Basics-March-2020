using System;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            int[] result = new int[value];

            for (int i = 0; i < value; i++)
            {
                int accumulator = int.Parse(Console.ReadLine());
                result[i] += accumulator;
            }

            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine(result.Sum());
        }
    }
}
