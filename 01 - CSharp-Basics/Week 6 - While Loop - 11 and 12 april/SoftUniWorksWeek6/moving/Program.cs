using System;

namespace moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());
            string boxesCount = Console.ReadLine();
            int freeSpace = width * length * hight;
            double spaceNeeded = 0;
            
            while (boxesCount != "Done" && spaceNeeded < freeSpace)
            {
                int boxes = int.Parse(boxesCount);
                spaceNeeded += boxes;
                if (spaceNeeded > freeSpace)
                {
                    Console.WriteLine($"No more free space! You need {spaceNeeded - freeSpace} Cubic meters more.");
                    break;
                }
                boxesCount = Console.ReadLine();
            }
            if (freeSpace > spaceNeeded)
            {
                Console.WriteLine($"{freeSpace - spaceNeeded} Cubic meters left.");
            }
        }
    }
}