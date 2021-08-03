using System;

namespace aquarium
{
    class Program
    {
        static void Main(string[] args)
        {

            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            
            double percentage = double.Parse(Console.ReadLine());

            int volume = lenght * width * height;
            double liters = volume * 0.001;
            double sand = liters * percentage / 100;
            double remaining = liters - sand;

            Console.WriteLine($"{remaining:f3}");
        }
    }
}
