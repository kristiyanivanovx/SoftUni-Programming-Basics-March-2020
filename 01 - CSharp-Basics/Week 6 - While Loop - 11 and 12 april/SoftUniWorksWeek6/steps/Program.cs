﻿using System;

namespace steps
{
    class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            int totalSteps = 0;
            bool isReached = false;
            bool isGoingHome = false;

            while (!isReached && !isGoingHome)
            {
                string input = Console.ReadLine();
                int currSteps = 0;
                if (input == "Going home")
                {
                    isGoingHome = true;
                    currSteps = int.Parse(Console.ReadLine());
                }
                else
                {
                    currSteps = int.Parse(input);
                }

                totalSteps += currSteps;

                if (totalSteps >= goal)
                {

                    isReached = true;
                }
            }
            if (isReached)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goal-totalSteps} more steps to reach goal.");
            }
        }
    }
}
