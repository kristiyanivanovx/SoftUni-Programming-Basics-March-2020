using System;

namespace beeHivePopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int startPopulation = int.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            int population = startPopulation;

            // to do calculations
            for (int i = 1; i <= years; i++)
            {

                int migration = 0;

                int grow = (population / 10) * 2;
                population += grow;

                if (i % 5 == 0)
                {
                    migration = (population / 50) * 5;
                    population -= migration;

                }

                int dead = (population / 20) * 2;
                population -= dead;

            }

            Console.WriteLine($"Beehive population: {population}");
        }
    }
}
