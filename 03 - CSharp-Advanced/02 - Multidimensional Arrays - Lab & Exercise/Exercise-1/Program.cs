using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int input = int.Parse(Console.ReadLine());
            int input = 3;

            int [,] matrix = new int[input, input];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = row + col;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.WriteLine(matrix[row, col]);
                }
            }
        }
    }
}
