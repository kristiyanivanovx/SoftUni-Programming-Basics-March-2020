using System;

namespace numbersSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = 0; i < count; i++)
            {
                int currNumber = int.Parse(Console.ReadLine());
                if (currNumber > maxNumber)
                {
                    maxNumber = currNumber;
                }

                if (currNumber < minNumber)
                {
                    minNumber = currNumber;
                }
            }
            Console.WriteLine($"Max number: {maxNumber}");
            Console.WriteLine($"Min number: {minNumber}");
        }
    }
}
