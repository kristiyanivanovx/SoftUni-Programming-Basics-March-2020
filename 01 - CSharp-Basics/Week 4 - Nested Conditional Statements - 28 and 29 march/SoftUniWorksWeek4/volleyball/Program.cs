using System;

namespace volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            double weekendForGame = 48;
            double weekend = weekendForGame - h;
            double gameSofia = weekend * 0.75;
            double totalGames = (p * 2.0 / 3.0) + gameSofia + h;

            if (year == "normal")
            {

                Console.WriteLine($"{Math.Floor(totalGames)}");
            }
            else if (year == "leap")
            {
                double leapYear = Math.Round(totalGames * 0.15, 3);
                double allyear = totalGames + leapYear;
                Console.WriteLine($"{Math.Floor(allyear)}");
            }
        }
    }
}
