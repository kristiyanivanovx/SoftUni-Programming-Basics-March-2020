using System;

namespace building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            string type = "";
            for (int rows = floors; rows >= 1; rows--)
            {
                for (int columns = 0; columns < rooms; columns++)
                {
                    if (rows == floors)
                    {
                        type = "L";
                    }
                    else
                    {
                        if (rows % 2 == 0)
                        {
                            type = "O";
                        }
                        else
                        {
                            type = "A";
                        }
                    }
                    Console.Write($"{type}{rows}{columns} ");
                }
                Console.WriteLine();
            }
        }
    }
}
