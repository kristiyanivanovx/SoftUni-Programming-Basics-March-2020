using System;
using System.Collections.Generic;
using System.Linq;

namespace HeartDelivery
{
    class Place
    {
        public Place(int value)
        {
            this.Value = value;
            this.HadValentine = false;
        }

        public int Value { get; set; }
        public bool HadValentine { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int currentIndex = 0;
            bool isSuccessful = true;

            List<Place> elements = new List<Place>();
            string[] rawData = Console.ReadLine().Split("@");

            rawData.ToList().ForEach(x => elements.Add(new Place(int.Parse(x))));
            string command = Console.ReadLine();

            while (!command.Contains("Love!"))
            {
                int length = int.Parse(command.Split()[1]);
                if (currentIndex + length >= elements.Count)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex += length;
                }

                Place place = elements.FirstOrDefault(x => elements.IndexOf(x) == currentIndex);
                if (place.Value == 0 && !place.HadValentine)
                {
                    Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                    place.HadValentine = true;
                }
                else if (place.HadValentine)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                }
                else
                {
                    place.Value -= 2;
                    if (place.Value == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                        place.HadValentine = true;
                    }
                }

                command = Console.ReadLine();
            }

            int failedCount = 0;
            Console.WriteLine($"Cupid's last position was {currentIndex}.");
            elements.ForEach(x =>
            {
                if (x.Value > 0)
                {
                    isSuccessful = false;
                    failedCount++;
                }
            });

            if (isSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedCount} places.");
            }
        }
    }
}
