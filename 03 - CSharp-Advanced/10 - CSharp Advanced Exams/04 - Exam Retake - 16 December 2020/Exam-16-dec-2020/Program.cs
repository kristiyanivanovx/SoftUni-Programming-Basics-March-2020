using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam16dec2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] ingridients = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> liquidsQueue = new Queue<int>(liquids);
            Stack<int> ingridientsStack = new Stack<int>(ingridients);

            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int fruitPies = 0;

            while (liquidsQueue.Any() && ingridientsStack.Any())
            {
                var currLiquid = liquidsQueue.Peek();
                var currIngridient = ingridientsStack.Peek();
                var sum = currLiquid + currIngridient;

                if (sum == 25)
                {
                    breads++;
                    liquidsQueue.Dequeue();
                    ingridientsStack.Pop();
                }
                else if (sum == 50)
                {
                    cakes++;
                    liquidsQueue.Dequeue();
                    ingridientsStack.Pop();
                }
                else if (sum == 75)
                {
                    pastries++;
                    liquidsQueue.Dequeue();
                    ingridientsStack.Pop();
                }
                else if (sum == 100)
                {
                    fruitPies++;
                    liquidsQueue.Dequeue();
                    ingridientsStack.Pop();
                }
                else
                {
                    var removedLiquid = liquidsQueue.Dequeue();
                    var tempIngridient = ingridientsStack.Pop() + 3;
                    ingridientsStack.Push(tempIngridient);
                }
            }

            if (breads > 0 && cakes > 0 && pastries > 0 && fruitPies > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquidsQueue.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                //"Liquids left: {liquid1}, {liquid2}, {liquid3}, (…)"
                Console.Write("Liquids left: ");
                Console.Write(string.Join(", ", liquidsQueue));
                Console.WriteLine();
            }

            if (ingridientsStack.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.Write("Ingredients left: ");
                Console.Write(string.Join(", ", ingridientsStack));
                Console.WriteLine();
            }

            Console.WriteLine($"Bread: {breads}");
            Console.WriteLine($"Cake: {cakes}");
            Console.WriteLine($"Fruit Pie: {fruitPies}");
            Console.WriteLine($"Pastry: {pastries}");
        }
    }
}
