using System;

namespace worldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double len = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double delay = Math.Floor(len / 15) * 12.5;

            double totalTime = (len * timeForMeter) + delay;

            if (totalTime < record)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime - record:f2} seconds slower.");
            }
        }
    }
}
