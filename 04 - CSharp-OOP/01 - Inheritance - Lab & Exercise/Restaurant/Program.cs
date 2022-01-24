using Restaurant.Foods;
using Restaurant.Foods.Meals;
using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Cake cake = new Cake("asd");
            Console.WriteLine(cake.Price);
            Console.WriteLine(cake.Calories);
        }
    }
}
