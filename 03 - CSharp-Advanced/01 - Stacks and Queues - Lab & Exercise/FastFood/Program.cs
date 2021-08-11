using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantiyOfFood = int.Parse(Console.ReadLine());
            int[] quantiyOfOrder = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(quantiyOfOrder);

            if (queue.Any())
            {
                Console.WriteLine(queue.Max());
            }

            foreach (var order in quantiyOfOrder)
            {
                if (quantiyOfFood >= order)
                {
                    queue.Dequeue();
                    quantiyOfFood -= order;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", queue));
            }
        }
    }
}
