using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int won = 0;
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (energy >= 0)
            {
                if (command.Contains("End of battle"))
                {
                    break;
                }

                int distance = int.Parse(command);
                if (distance > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {energy} energy");
                }

                energy -= distance;
                won++;

                if (won % 3 == 0)
                {
                    energy += won;
                }

                command = Console.ReadLine();
            }

            if (energy >= 0)
            {
                Console.WriteLine($"Won battles: {won}. Energy left: {energy}");
            }
        }
    }
}
