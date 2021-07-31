using System;

namespace alcoholShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double rakiaLiters = double.Parse(Console.ReadLine());
            double whiskeyLiters = double.Parse(Console.ReadLine());

            double rakiaPrice = whiskeyPrice / 2;
            double winePrice = rakiaPrice - (rakiaPrice * 40) / 100;
            double beerPrice = rakiaPrice - (rakiaPrice * 80) / 100;

            double whiskeyValue = whiskeyPrice * whiskeyLiters;
            double beerValue = beerPrice * beerLiters;
            double wineValue = winePrice * wineLiters;
            double rakiaValue = rakiaPrice * rakiaLiters;
            double sumAlc = whiskeyValue + beerValue + wineValue + rakiaValue;
            Console.WriteLine($"{sumAlc:f2}");

        }
    }
}
