using System;
using System.Collections.Generic;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> productShops = new SortedDictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();

            while (input.ToLower() != "revision")
            {
                string[] actual = input.Split(", ");

                string shop = actual[0];
                string product = actual[1];
                double price = double.Parse(actual[2]);

                if (!productShops.ContainsKey(shop))
                {
                    productShops.Add(shop, new Dictionary<string, double>());
                }

                if (!productShops[shop].ContainsKey(product))
                {
                    productShops[shop].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var shop in productShops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
