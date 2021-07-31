using System;

namespace multiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int row = 1; row <= 10; row++)
            {
                for (int col = 1; col <= 10; col++)
                {
                    Console.WriteLine($"{row} * {col} = {row * col}");
                }
            }
        }
    }
}
