using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@\#+[A-Z][A-Za-z0-9]{4,}[A-Z]@\#+";

            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                MatchCollection matches = Regex.Matches(input, pattern);

                if (matches.Any())
                {
                    string product = "";
                    foreach (Match m in matches)
                    {
                        foreach (char item in m.Value)
                        {
                            if (int.TryParse(item.ToString(), out _))
                            {
                                product += item;
                            }
                        }

                        if (product == "")
                        {
                            product = "00";
                        }

                        Console.WriteLine($"Product group: {product}");
                        product = "";
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

                input = Console.ReadLine();
            }
        }
    }
}
