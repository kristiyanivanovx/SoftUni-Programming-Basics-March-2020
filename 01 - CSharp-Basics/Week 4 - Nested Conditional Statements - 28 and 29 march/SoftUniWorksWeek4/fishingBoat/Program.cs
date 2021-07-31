using System;

namespace fishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFisherman = int.Parse(Console.ReadLine());

            double rentPriceBoat = 0;
            double discount = 0;
            double bonusDiscount = 0;
            double totalPrice = 0;

            if (season == "Spring")
            {
                rentPriceBoat = 3000;
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rentPriceBoat = 4200;
            }
            else if (season == "Winter")
            {
                rentPriceBoat = 2600;
            }

            if (countFisherman <= 6)
            {
                discount = 0.90;
            }
            else if (countFisherman >= 7 && countFisherman <= 11)
            {
                discount = 0.85;
            }
            else if (countFisherman >= 12)
            {
                discount = 0.75;
            }

            if (countFisherman % 2 == 0 && season != "Autumn")
            {
                bonusDiscount = 0.95;
                totalPrice = (rentPriceBoat * discount) * bonusDiscount;
            }
            else
            {
                totalPrice = (rentPriceBoat * discount);
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Yes! You have {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalPrice - budget:f2} leva.");
            }
        }
    }
}