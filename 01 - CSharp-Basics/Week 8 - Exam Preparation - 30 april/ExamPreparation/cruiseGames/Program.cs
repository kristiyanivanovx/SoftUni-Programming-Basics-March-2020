using System;

namespace cruiseGames
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            int countPlays = int.Parse(Console.ReadLine());

            int countVolleyball = 0;
            double pointsVolleyball = 0;

            int countTennis = 0;
            double pointsTennis = 0;

            int countBadminton = 0;
            double pointsBadminton = 0;

            for (int i = 1; i <= countPlays; i++)
            {
                string gameName = Console.ReadLine();
                int points = int.Parse(Console.ReadLine());

                if (gameName == "volleyball")
                {
                    countVolleyball++;
                    pointsVolleyball += points + 0.07 * points;
                }
                else if (gameName == "tennis")
                {
                    countTennis++;
                    pointsTennis += points + 0.05 * points;
                }
                else if (gameName == "badminton")
                {
                    countBadminton++;
                    pointsBadminton += points + 0.02 * points;
                }
            }

            double averageVolleyball = pointsVolleyball / countVolleyball;
            double averageTennis = pointsTennis / countTennis;
            double averageBadminton = pointsBadminton / countBadminton;

            double totalPoints = Math.Floor(pointsVolleyball + pointsTennis + pointsBadminton);

            if (averageVolleyball >= 75 && averageTennis >= 75 && averageBadminton >= 75)
            {

                Console.WriteLine($"Congratulations, {playerName}! You won the cruise games with {totalPoints} points.");
            }
            else
            {
                Console.WriteLine($"Sorry, {playerName}, you lost. Your points are only {totalPoints}.");
            }
        }
    }
}
