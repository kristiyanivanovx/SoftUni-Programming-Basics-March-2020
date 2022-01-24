using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int swaps = int.Parse(Console.ReadLine());

            for (int i = 0; i < swaps; i++)
            {
                int temp = values[0];
                for (int k = 0; k < values.Length - 1; k++)
                {
                    values[k] = values[k + 1];
                }

                values[values.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(" ", values));
        }
    }
}
