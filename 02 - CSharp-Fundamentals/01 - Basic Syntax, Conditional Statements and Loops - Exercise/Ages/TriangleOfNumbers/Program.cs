using System;

namespace TriangleOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());

            for (int row = 1; row <= value; row++)
            {
                for (int col = 0; col < row; col++)
                {
                    Console.Write(row + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
