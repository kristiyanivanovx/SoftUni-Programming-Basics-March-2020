using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            string biggestModel = string.Empty;
            float biggestVolume = float.MinValue;

            int value = int.Parse(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                float volume = MathF.PI * MathF.Pow(radius, 2) * height;
                if (volume > biggestVolume)
                {
                    biggestModel = model;
                    biggestVolume = volume;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
