using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[3];
            ReadInput(numbers);

            int minValue = FindMinValue(numbers);
            Console.WriteLine(minValue);
        }

        private static void ReadInput(int[] numbers)
        {
            for (int i = 0; i < 3; i++)
            {
                int value = int.Parse(Console.ReadLine());
                numbers[i] = value;
            }
        }

        static int FindMinValue(int[] numbers)
        {
            int minValue = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            return minValue;
        }
    }
}
