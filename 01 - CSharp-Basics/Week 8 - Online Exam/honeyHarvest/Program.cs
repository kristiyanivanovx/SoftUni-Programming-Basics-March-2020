using System;

namespace honeyHarvest
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double production = 0;

            switch (season)
            {
                case "Spring":
                    if (flowerType == "Sunflower")
                    {
                        production = 10 * flowerCount;
                    }
                    else if (flowerType == "Daisy")
                    {
                        production = (12 * 1.10) * flowerCount;
                    }
                    else if (flowerType == "Lavender")
                    {
                        production = 12 * flowerCount;
                    }
                    else if (flowerType == "Mint")
                    {
                        production = (10 * 1.10) * flowerCount;
                    }

                    break;

                case "Summer":
                    if (flowerType == "Sunflower")
                    {
                        production = 8 * flowerCount;
                    }
                    else if (flowerType == "Daisy")
                    {
                        production = 8 * flowerCount;
                    }
                    else if (flowerType == "Lavender")
                    {
                        production = 8 * flowerCount;
                    }
                    else if (flowerType == "Mint")
                    {
                        production = 12 * flowerCount;
                    }
                    production *= 1.10;

                    break;

                case "Autumn":
                    if (flowerType == "Sunflower")
                    {
                        production = 12 * flowerCount;
                    }
                    else if (flowerType == "Daisy")
                    {
                        production = 6 * flowerCount;
                    }
                    else if (flowerType == "Lavender")
                    {
                        production = 6 * flowerCount;
                    }
                    else if (flowerType == "Mint")
                    {
                        production = 6 * flowerCount;
                    }
                    production *= 0.95;
                    break;
            }
            Console.WriteLine($"Total honey harvested: {production:f2}");
        }
    }
}
