using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            int leftDiagonal = 0;
            int rightDiagonal = 0;
            for (int row = 0; row < size; row++)
            {
                rightDiagonal += matrix[row][row];
                leftDiagonal += matrix[row][matrix[row].Length - 1 - row];
            }
            ;

            Console.WriteLine(Math.Abs(leftDiagonal - rightDiagonal));
        }
    }
}
