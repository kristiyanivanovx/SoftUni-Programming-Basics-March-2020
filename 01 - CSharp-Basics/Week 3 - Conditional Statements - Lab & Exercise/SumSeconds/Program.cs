using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSeconds = 0;
            
            // read times

            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            totalSeconds += int.Parse(Console.ReadLine());
            // totalSeconds += int.Parse(Console.ReadLine());

            // sum total times

            // calculation

            int minutes = 0;
            int seconds = 0;

            if (totalSeconds >= 120)
            {
                minutes = 2;
                seconds = totalSeconds - 120;
            }
            else if (totalSeconds >= 60)
            {
                minutes = 1;
                seconds = totalSeconds - 60;
            }
            else
            {
                minutes = 0;
                seconds = totalSeconds;
            }

            // print m : ss -> 1:05 leading 0 format
            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
