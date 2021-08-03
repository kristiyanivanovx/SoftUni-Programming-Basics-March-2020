using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0.0;

            switch (projectionType)
            {
                case "Premiere":
                    income = rows * columns * 12.0;
                    
                    break;

                case "Normal":
                    income = rows * columns * 7.5;
                    break;

                case "Discount":
                    income = rows * columns * 5.0;
                    break;

                default:
                    break;

            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
