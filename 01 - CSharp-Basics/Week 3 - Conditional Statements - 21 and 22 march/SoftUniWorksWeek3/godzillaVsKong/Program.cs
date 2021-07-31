using System;

namespace godzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double statists = double.Parse(Console.ReadLine());
            double priceCostume = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;

            if (statists > 150)
            {
                priceCostume = priceCostume * 0.90;
            }

            double expenses = decor + priceCostume;

            if (expenses > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {expenses - budget} leva more.");
            }
            else if (expenses <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - expenses} leva left.");
            }
        }
    }
}
