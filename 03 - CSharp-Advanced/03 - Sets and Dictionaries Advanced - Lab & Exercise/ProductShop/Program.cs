using System;
using System.Collections.Generic;

namespace ProductShop
{
    // dictionaries

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] actual;

            SortedDictionary<string, Dictionary<string, double>> productShop =
                new SortedDictionary<string, Dictionary<string, double>>();

            while (input.ToLower() != "revision")
            {
                actual = input.Split(", ");

                string shop = actual[0];
                string product = actual[1];
                double price = double.Parse(actual[2], 
                    System.Globalization.CultureInfo.InvariantCulture);

                if (!productShop.ContainsKey(shop))
                {
                    productShop.Add(shop, new Dictionary<string, double>());
                }

                if (!productShop[shop].ContainsKey(product))
                {
                    productShop[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var shop in productShop)
            {
                Console.WriteLine($"{shop.Key} -> ");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
