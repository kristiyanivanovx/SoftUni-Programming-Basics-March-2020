using System;
using System.Linq;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			char[,] matrix = new char[n, n];

			int snakeRow = -1;
			int snakeCol = -1;

			for (int row = 0; row < n; row++)
			{
				char[] individualElements = Console.ReadLine().ToCharArray();

				for (int col = 0; col < n; col++)
				{
					matrix[row, col] = individualElements[col];

					if (matrix[row, col] == 'S')
					{
						snakeRow = row;
						snakeCol = col;
					}
				}
			}

			// parse commands
			string command = Console.ReadLine();
			while (command != "")
			{
				if (command == "up")
				{
					matrix[snakeRow, snakeCol] = '.';


					matrix[snakeRow - 1, snakeCol] = 'S';
				}
				else if (command == "down")
				{
					matrix[snakeRow, snakeCol] = '.';
					matrix[snakeRow + 1, snakeCol] = 'S';

				}
				else if (command == "left")
				{
					matrix[snakeRow, snakeCol] = '.'; 
					matrix[snakeRow, snakeCol - 1] = 'S';

				}
				else if (command == "right")
				{
					matrix[snakeRow, snakeCol] = '.';
					matrix[snakeRow, snakeCol + 1] = 'S';
				}

				command = Console.ReadLine();
			}

			//for (int row = 0; row < matrix.GetLength(0); row++)
			//{
			//	for (int col = 0; col < matrix.GetLength(1); col++)
			//	{
			//		Console.Write(matrix[row, col]);
			//	}
			//	Console.WriteLine();
			//}
		}
	}
}
