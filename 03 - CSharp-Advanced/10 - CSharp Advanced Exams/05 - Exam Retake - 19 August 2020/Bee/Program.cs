using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int polinated = 0;

            int beeCol= 0;
            int beeRow = 0;

            for (int row = 0; row < n; row++)
            {
                string cells = Console.ReadLine();
                for (int col = 0; col < cells.Length; col++)
                {
                    if (cells[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }

                    matrix[row, col] = cells[col];
                }
            }
            
            string command = Console.ReadLine();

            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!IsPositionValid(beeRow, beeCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    matrix[beeRow, beeCol] = '.';
                    polinated++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!IsPositionValid(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        matrix[beeRow, beeCol] = '.';
                        polinated++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }

            if (polinated >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinated} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinated} flowers more");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "right")
            {
                return col + 1;
            }
            if (movement == "left")
            {
                return col - 1;
            }

            return col;
        }
    }
}
