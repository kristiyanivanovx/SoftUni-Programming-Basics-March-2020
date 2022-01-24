using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());

            for (int k = 0; k < value; k++)
            {
                for (int i = 0; i < value; i++)
                {
                    for (int j = 0; j < value; j++)
                    {
                        char first = (char)('a' + k);
                        char second = (char)('a' + i);
                        char third = (char)('a' + j);
                        Console.Write(first + "" + second + "" + third);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
