using System;

namespace summerShopping
{
    class Program
    {
        static void Main(string[] args)
        {
            // towel = input
            // umbrella = towel * 2/3
            // flip flops 70% * umbrella
            // bag = 1/3 * (flip flops + towel)
            // sum = towel + umbrella + bag + flip flops

            int budget = int.Parse(Console.ReadLine());
            double towelPrice = double.Parse(Console.ReadLine());
            int discountPercent = int.Parse(Console.ReadLine());

            double umbrellaPrice = towelPrice * 2 / 3;
            double flipFlopsPrice = 0.75 * umbrellaPrice;
            double bagPrice = (flipFlopsPrice + towelPrice) / 3;

            double totalSum = towelPrice + umbrellaPrice + bagPrice + flipFlopsPrice;

            totalSum -= (discountPercent / 100.0) * totalSum;
            if (budget >= totalSum)
            {
                double leftMoney = budget - totalSum;
                Console.WriteLine($"Annie's sum is {totalSum:f2} lv. She has {leftMoney:f2} lv. left.");
            }
            else
            {
                double neededMoney = totalSum - budget;
                Console.WriteLine($"Annie's sum is {totalSum:f2} lv. She needs {neededMoney:f2} lv. more.");
            }
        }
    }
}
