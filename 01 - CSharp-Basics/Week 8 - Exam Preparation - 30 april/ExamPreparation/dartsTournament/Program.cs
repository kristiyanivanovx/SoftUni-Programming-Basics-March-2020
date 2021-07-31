using System;

namespace dartsTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int startPoints = int.Parse(Console.ReadLine());

            while (startPoints > 0)
            {
                string sector = Console.ReadLine();
                count++;

                if (sector == "number section")
                {
                    int pointsFromSector = int.Parse(Console.ReadLine());
                    startPoints -= pointsFromSector;
                }
                else if (sector == "double ring")
                {
                    int pointsFromSector = int.Parse(Console.ReadLine());
                    startPoints -= pointsFromSector * 2;
                }
                else if (sector == "triple ring")
                {
                    int pointsFromSector = int.Parse(Console.ReadLine());
                    startPoints -= pointsFromSector * 3;
                }
                else if (sector == "bullseye")
                {
                    Console.WriteLine($"Congratulations! You won the game with a bullseye in {count} moves!");
                    break;
                }

                if (startPoints < 0)
                {
                    Console.WriteLine($"Sorry, you lost. Score difference: {Math.Abs(startPoints)}.");
                    break;
                }
            }

            if (startPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {count} moves!");
            }
        }
    }
}
