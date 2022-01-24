using System;
using System.Linq;

namespace MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int keyNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < values.Length; i++)
            {
                for (int k = i + 1; k < values.Length; k++)
                {
                    if (values[i] + values[k] == keyNumber)
                    {
                        Console.WriteLine(values[i] + " " + values[k]);
                    }
                }
            }
        }
    }
}
