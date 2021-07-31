using System;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tableCount = int.Parse(Console.ReadLine());

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double clothSize = (length + 0.60) * (width + 0.60);
            double squareSize = (length / 2) * (length / 2);

            double totalPrice = tableCount * (clothSize * 7 + squareSize * 9);

            Console.WriteLine($"{totalPrice:f2} USD");
            Console.WriteLine($"{totalPrice*1.85:f2} BGN");


        }
    }
}
