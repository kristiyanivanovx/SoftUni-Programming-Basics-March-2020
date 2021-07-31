using System;

namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[,] matrix = new int[2, 2] 
            int[,] matrix = new int[,] 
            {
                {1, 3, 7},
                {2, 4, 6},
            };

            //matrix[0, 0] = 1;
            //matrix[0, 1] = 3;
            //matrix[1, 0] = 2;
            //matrix[1, 1] = 4;

            // 1, 3
            // 2, 4

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
