using System;

namespace fruitOrVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();

            switch (fruit)
            {
                case "banana":
                case "cherry": 
                case "lemon":
                case "apple":
                case "grapes":
                case "kiwi":
                    Console.WriteLine("fruit");
                    break;

                case "tomato":
                case "cucumber":
                case "potato":
                case "pepper":
                case "carrot":
                        Console.WriteLine("vegetable");
                        break;

                default:
                    Console.WriteLine("unknown");
                    break;

            }
        }
    }
}
