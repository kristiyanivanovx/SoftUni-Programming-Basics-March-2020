using System;

namespace honeyWinterReserves
{
    class Program
    {
        static void Main(string[] args)
        {
            int honeyNeeded = int.Parse(Console.ReadLine());
            string command = "";
            double honeyTotal = 0.0;

            while (command != "Winter has come")
            {
                string beeName = Console.ReadLine();
                for (int i = 1; i <= 6; i++)
                {
                    double honeyAcquired = double.Parse(Console.ReadLine());
                    honeyTotal += honeyAcquired;
                }

                if (honeyTotal < 0)
                {
                    Console.WriteLine($"{beeName} was banished for gluttony");
                    continue;
                }

                command = Console.ReadLine();
            }
            if (honeyNeeded < honeyTotal)
            {
                Console.WriteLine($"Well done! Honey surplus {honeyTotal - honeyNeeded:f2}.");
            }
            else if (honeyNeeded > honeyTotal)
            {
                Console.WriteLine($"Hard Winter! Honey needed {honeyNeeded - honeyTotal:f2}.");
            }
        }
    }
}
