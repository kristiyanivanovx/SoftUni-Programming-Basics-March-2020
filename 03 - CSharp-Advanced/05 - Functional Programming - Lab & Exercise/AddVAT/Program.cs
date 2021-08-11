using System;
using System.Linq;

namespace AddVAT
{
    class Program
    { 
        static void Main(string[] args)
        {
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
