using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0;

            switch (flowerType)
            {
                case "Roses":
                    price = 5;
                    if (count > 80)
                    {
                        price *= 0.90;
                    }
                    break;

                case "Dahlias":
                    price = 3.80;
                    if (count > 90)
                    {
                        price *= 0.85;
                    }
                    break;

                case "Tulips":
                    price = 2.80;
                    if (count > 80)
                    {
                        price *= 0.85;
                    }
                    break;

                case "Narcissus":
                    price = 3;
                    if (count < 120)
                    {
                        price *= 1.15;
                    }
                    break;

                case "Gladiolus":
                    price = 2.50;
                    if (count < 80)
                    {
                        price *= 1.20;
                    }
                    break;
            }
            double totalCost = price * count;
            if (budget >= totalCost)
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {flowerType} and {budget - totalCost:f2} leva left.");
            }
            else if (budget < totalCost)
            {
                Console.WriteLine($"Not enough money, you need {totalCost - budget:f2} leva more.");
            }
        }
    }
}
