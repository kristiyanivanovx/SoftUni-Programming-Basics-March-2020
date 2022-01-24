using System;
using System.Linq;

namespace ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldTakeSecond = false;
            int value = int.Parse(Console.ReadLine());
            int[] firstArray = new int[value];
            int[] secondArray = new int[value];

            for (int i = 0; i < value; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (shouldTakeSecond)
                {
                    secondArray[i] = values[1];
                    firstArray[i] = values[0];
                }
                else
                {
                    secondArray[i] = values[0];
                    firstArray[i] = values[1];
                }

                shouldTakeSecond = !shouldTakeSecond;
            }

            Console.WriteLine(string.Join(" ", secondArray));
            Console.WriteLine(string.Join(" ", firstArray));
        }
    }
}
