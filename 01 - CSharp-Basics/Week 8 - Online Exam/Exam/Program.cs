using System;

namespace honeycombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beeCount = int.Parse(Console.ReadLine());
            int flowerCount = int.Parse(Console.ReadLine());

            double honeyAmount = beeCount * flowerCount * 0.21;
            double honeycombs = 0;
            double honeyGramsLeft = 0;

            if (honeyAmount >= 100)
            {
                honeycombs = honeyAmount / 100.0;
                honeycombs = Math.Floor(honeycombs);
                honeyGramsLeft = honeyAmount - honeycombs * 100.0;
            }

            Console.WriteLine($"{honeycombs} honeycombs filled.");
            Console.WriteLine($"{honeyGramsLeft:f2} grams of honey left");
        }
    }
}
