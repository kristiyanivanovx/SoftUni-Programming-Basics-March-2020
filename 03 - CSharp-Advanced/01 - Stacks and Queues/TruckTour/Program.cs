using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> pumpsData = new Queue<string>();
            int pumpsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pumpsCount; i++)
            {
                pumpsData.Enqueue(Console.ReadLine());
            }

            for (int i = 0; i < pumpsCount; i++)
            {
                bool isSuccessfull = true;
                int currPetrolAmount = 0;

                for (int j = 0; j < pumpsCount; j++)
                {
                    int[] pumpData = pumpsData.Dequeue().Split(" ").Select(int.Parse).ToArray();
                    pumpsData.Enqueue(string.Join(" ", pumpData));

                    currPetrolAmount += pumpData[0];
                    currPetrolAmount -= pumpData[1];

                    if (currPetrolAmount < 0)
                    {
                        isSuccessfull = false;
                    }
                }

                if (isSuccessfull)
                {
                    Console.WriteLine(i);
                    break;
                }

                pumpsData.Enqueue(pumpsData.Dequeue());
            }
        }
    }
}
