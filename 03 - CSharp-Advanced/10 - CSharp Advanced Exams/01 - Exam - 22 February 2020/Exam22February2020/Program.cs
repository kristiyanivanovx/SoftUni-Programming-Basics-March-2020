using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam22February2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootbox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLootbox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> firstLooboxQueue = new Queue<int>(firstLootbox);
            Stack<int> secondLooboxStack = new Stack<int>(secondLootbox);

            int collectedItems = 0;

            while (firstLooboxQueue.Any() && secondLooboxStack.Any())
            {
                int firstHalf = firstLooboxQueue.Peek();
                int secondHalf = secondLooboxStack.Peek();
                int sum = firstHalf + secondHalf;

                if (sum % 2 == 0)
                {
                    collectedItems += sum;
                    firstLooboxQueue.Dequeue();
                    secondLooboxStack.Pop();
                }
                else
                {
                    int lastItemSecondBox = secondLooboxStack.Pop();
                    firstLooboxQueue.Enqueue(lastItemSecondBox);
                }
            }

            if (firstLooboxQueue.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondLooboxStack.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (collectedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectedItems}");
            }
        }
    }
}
