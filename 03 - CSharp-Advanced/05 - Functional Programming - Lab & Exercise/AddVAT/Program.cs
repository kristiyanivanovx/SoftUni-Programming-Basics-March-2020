using System;
using System.Linq;

namespace AddVAT
{
    class Program
    { 
        // exe 4
        static void Main(string[] args)
        {
            // 1,38, 2,56, 4,4
            // 1.66
            // 3.07
            // 5.28

            double[] prices = Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(x => x *= 1.2)
                .ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine(Math.Round(price, 2).ToString("N2"));
            }

        }
    }
}
