using System;

namespace tradingCommissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double sum = 0;

            switch (town)
            {
                case "Sofia":
                    if (sales >= 0 && 500 >= sales)
                    {
                        sum = sales * 5 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 500 && 1000 >= sales)
                    {
                        sum = sales * 7 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 1000 && 10000 >= sales)
                    {
                        sum = sales * 8 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 10000)
                    {
                        sum = sales * 12 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "Varna":
                    if (sales >= 0 && 500 >= sales)
                    {
                        sum = sales * 4.5 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 500 && 1000 >= sales)
                    {
                        sum = sales * 7.5 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 1000 && 10000 >= sales)
                    {
                        sum = sales * 10 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 10000)
                    {
                        sum = sales * 13 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "Plovdiv":
                    if (sales >= 0 && 500 >= sales)
                    {
                        sum = sales * 5.5 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 500 && 1000 >= sales)
                    {
                        sum = sales * 8 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 1000 && 10000 >= sales)
                    {
                        sum = sales * 12 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else if (sales > 10000)
                    {
                        sum = sales * 14.5 / 100;
                        Console.WriteLine($"{sum:f2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
