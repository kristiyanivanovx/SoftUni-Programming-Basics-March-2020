using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> swapList = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                int element = int.Parse(Console.ReadLine());

                //Box<string> newBox = new Box<string>(element);
                Box<int> newBox = new Box<int>(element);
                swapList.Add(newBox);
            }

            int[] providedIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SwapMethod<int>(swapList, providedIndexes[0], providedIndexes[1]);

            foreach (var element in swapList)
            {
                var elName = element.GetType().Name;
                Console.WriteLine($"System.Int32: {element.Value}");
                //Console.WriteLine($"System.String: {element.Value}");
            }
        }

        private static void SwapMethod<T>(List<Box<T>> list, int firstIndex, int secondIndex)
        {
            T tempFirst = list[firstIndex].Value;
            T tempSecond = list[secondIndex].Value;
            
            list[firstIndex] = new Box<T>(tempSecond);
            list[secondIndex] = new Box<T>(tempFirst);
        }
    }
}
