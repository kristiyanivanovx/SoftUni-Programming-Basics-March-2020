using System;

namespace bakingCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakers = int.Parse(Console.ReadLine());

            int countAll = 0;
            int countAllCookies = 0;
            int countAllCakes = 0;
            int countAllWaffles = 0;

            for (int baker = 1; baker <= bakers; baker++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                int countCookiesPerBaker = 0;
                int countCakesPerBaker = 0;
                int countWafflesPerBaker = 0;

                while (type != "Stop baking!")
                {
                    int count = int.Parse(Console.ReadLine());
                    countAll += count;

                    switch (type)
                    {
                        case "cookies":
                            countCookiesPerBaker += count;
                            countAllCookies += count;
                            break;

                        case "cakes":
                            countCakesPerBaker += count;
                            countAllCakes += count;
                            break;

                        case "waffles":
                            countWafflesPerBaker += count;
                            countAllWaffles += count;
                            break;
                    }

                    type = Console.ReadLine();
                }

                Console.WriteLine($"{name} baked {countCookiesPerBaker} cookies, {countCakesPerBaker} cakes and {countWafflesPerBaker} waffles.");
            }

            double totalSum = (countAllCookies * 1.50) + (countAllCakes * 7.80) + (countAllWaffles * 2.30);
            Console.WriteLine($"All bakery sold: {countAll}");
            Console.WriteLine($"Total sum for charity: {totalSum:F2} lv.");
        }
    }
}
