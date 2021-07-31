using System;

namespace danceSalon
{
    class Program
    {
        static void Main(string[] args)
        {
            double lengthSalon = (double.Parse(Console.ReadLine()) * 100);
            double widthSalon = (double.Parse(Console.ReadLine()) * 100);
            double sideWardrobe = (double.Parse(Console.ReadLine()) * 100);
            double squareArea = lengthSalon * widthSalon;
            double areaWardrobe = sideWardrobe * sideWardrobe;
            double benchArea = squareArea / 10.0;
            double availableSpace = (squareArea - (areaWardrobe + benchArea)) / 7040.0;
            Console.WriteLine(Math.Floor(availableSpace));
        }
    }
}
