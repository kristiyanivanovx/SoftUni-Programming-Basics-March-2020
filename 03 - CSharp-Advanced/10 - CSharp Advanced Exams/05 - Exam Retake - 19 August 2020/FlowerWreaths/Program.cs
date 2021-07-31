using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);

            int wreathsCount = 0;
            int forLater = 0;

            while (rosesQueue.Any() && liliesStack.Any())
            {
                int rose = rosesQueue.Dequeue();
                int lily = liliesStack.Pop();

                int sum = rose + lily;
                
                if (sum == 15)
                {
                    wreathsCount++;
                }
                if (sum < 15)
                {
                    forLater += sum;
                }
                else if (sum > 15)
                {
                    while (sum > 15)
                    {
                        sum -= 2;

                        if (sum == 15)
                        {
                            wreathsCount++;
                            break;
                        }
                        else if (sum < 15)
                        {
                            forLater += sum;
                            break;
                        }
                    }
                }
            }

            forLater /= 15;

            if (forLater < 15)
            {
                wreathsCount += forLater;
            }
            
            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }
        }
    }
}
