using System;

namespace ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // read trip price 
            double tripPrice = double.Parse(Console.ReadLine());
            // read toys
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int bearCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());
            //calculate income
            double income = 0;
            income += puzzleCount * 2.6;
            income += dollCount * 3.00;
            income += bearCount * 4.10;
            income += minionCount * 8.20;
            income += truckCount * 2.00;
            // discount? -25% if > 50
            int totalToys = puzzleCount + dollCount + bearCount + minionCount + truckCount;
            // substract rent
            if (totalToys >= 50)
            {
                income *= 0.75;
            }
            
            income *= 0.90; // income = income * 0.90;

            // check money enough
            //print

            if (income >= tripPrice)
            {
                double remainingMoney = income - tripPrice;
                Console.WriteLine($"Yes! {remainingMoney:f2} lv left.");
            }
            else
            {
                double missingMoney = tripPrice - income;
                Console.WriteLine($"Not enough money! {missingMoney:f2} lv needed.");
            }
        }
    }
}
