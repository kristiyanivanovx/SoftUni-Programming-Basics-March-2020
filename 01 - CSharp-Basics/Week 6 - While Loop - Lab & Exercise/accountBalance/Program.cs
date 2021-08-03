using System;

namespace accountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int counter = 1;
            double totalBalance = 0;
            while (counter <= number)
            {
                double amount = double.Parse(Console.ReadLine());
                if (amount <= 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {amount:F2}");
                totalBalance += amount;
                counter++;
            }
            Console.WriteLine($"Total: {totalBalance:f2}");
        }
    }
}