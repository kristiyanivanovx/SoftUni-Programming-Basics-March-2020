using System;

namespace MatrixNxN
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());
            PrintMatrix(value);
        }

        private static void PrintMatrix(int value)
        {
            for (int i = 0; i < value; i++)
            {
                for (int k = 0; k < value; k++)
                {
                    Console.Write(value);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
        }
    }
}
