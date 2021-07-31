using System;

namespace numbersPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int current = 1;
            bool isBigger = false;
            for (int rows = 1; rows <= input; rows++)
            {
                for (int cols = 0; cols < rows; cols++)
                {
                    Console.Write(current + " ");
                    current++;

                    if (current > input)
                    {
                        isBigger = true;
                        break;
                    }
                }
                Console.WriteLine();
                if (isBigger)
                {
                    break;
                }
            }
        }
    }
}
