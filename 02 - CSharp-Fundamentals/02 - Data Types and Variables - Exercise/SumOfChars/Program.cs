using System;

namespace SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            int total = 0;

            for (int i = 0; i < value; i++)
            {
                total += char.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The sum equals: {total}");
        }
    }
}
