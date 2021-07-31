using System;

namespace areaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input == "square")
            {
                double squareA = double.Parse(Console.ReadLine());
                Console.WriteLine($"{squareA * squareA:f3}");
            }
            else if (input == "rectangle")
            {
                double rectangleA = double.Parse(Console.ReadLine());
                double rectangleB = double.Parse(Console.ReadLine());
                Console.WriteLine($"{rectangleA * rectangleB:f3}");
            }
            else if (input == "circle")
            {
                double circleRadius = double.Parse(Console.ReadLine());
                Console.WriteLine($"{Math.Pow(circleRadius, 2) * Math.PI:f3}");
            }
            else if (input == "triangle")
            {
                double triangleLength = double.Parse(Console.ReadLine());
                double triangleHeight = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(triangleLength * triangleHeight) / 2:f3}");
            }
        }
    }
}
