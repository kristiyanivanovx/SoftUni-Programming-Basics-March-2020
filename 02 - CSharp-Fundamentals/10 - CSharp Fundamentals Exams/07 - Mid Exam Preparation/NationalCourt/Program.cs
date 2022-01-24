using System;

namespace NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int breakTimestamp = 3;
            int hoursNeeded = 0;
            int count = 0;

            int efficiencyOne = int.Parse(Console.ReadLine());
            int efficiencyTwo = int.Parse(Console.ReadLine());
            int efficiencyThree = int.Parse(Console.ReadLine());

            int totalPeopleCount = int.Parse(Console.ReadLine());

            int totalEfficiency = efficiencyOne + efficiencyTwo + efficiencyThree;
            while (totalPeopleCount > 0)
            {
                totalPeopleCount -= totalEfficiency;

                if (count == breakTimestamp)
                {
                    hoursNeeded++;
                    count = 0;
                }

                hoursNeeded++;
                count++;
            }

            Console.WriteLine($"Time needed: {hoursNeeded}h.");
        }
    }
}
