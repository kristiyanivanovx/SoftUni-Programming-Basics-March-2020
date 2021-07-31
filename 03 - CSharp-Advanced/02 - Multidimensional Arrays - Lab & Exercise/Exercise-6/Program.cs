using System;

namespace Exercise_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //jagged

            //[0][1][2]
            //[0][1][2][3][4][5]
            //[0][1][2][3]

            int[][] jagged = new int[3][];

            jagged[0] = new int[3];
            jagged[1] = new int[2];
            jagged[2] = new int[4];

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = int.Parse(Console.ReadLine());
                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }

                Console.WriteLine();
            }

            //1
            //2
            //3
            //4
            //5
            //6
            //7
            //8
            //9

            //1 2 3
            //4 5
            //6 7 8 9
        }
    }
}
