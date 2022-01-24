using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam28June2020
{
    class Program
    {
        static void Main(string[] args)
        {
            // BOMBS!!! :D

            //->
            //bomb effects 
            //bomb casings
            //          <-

            // 5, 25, 50, 115
            // 5, 15, 25, 35

            int[] effects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] casings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> effectsQueue = new Queue<int>(effects);
            Stack<int> casingsStack = new Stack<int>(casings);

            int daturaScore = 0; // 40
            int cherryScore = 0; // 60
            int smokeDecoyScore = 0; // 120

            bool isPouchFilled = false;

            while (effectsQueue.Any() && casingsStack.Any())
            {
                int currEffect = effectsQueue.Peek();
                int currCasing = casingsStack.Peek();

                int sum = currEffect + currCasing;

                if (sum == 40)
                {
                    daturaScore++;
                    effectsQueue.Dequeue();
                    casingsStack.Pop();
                }
                else if(sum == 60)
                {
                    cherryScore++;
                    effectsQueue.Dequeue();
                    casingsStack.Pop();
                }
                else if (sum == 120)
                {
                    smokeDecoyScore++;
                    effectsQueue.Dequeue();
                    casingsStack.Pop();
                }
                else
                {
                    int currentCasingToBeDecreased = casingsStack.Pop();
                    currentCasingToBeDecreased -= 5;
                    casingsStack.Push(currentCasingToBeDecreased);
                }

                // pouch filled
                if (daturaScore >= 3 && cherryScore >= 3 && smokeDecoyScore >= 3)
                {
                    isPouchFilled = true;
                    break;
                }
            }

            if (daturaScore >= 3 && cherryScore >= 3 && smokeDecoyScore >= 3)
            {
                isPouchFilled = true;
            }

            if (isPouchFilled)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
            }

            if (effectsQueue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(string.Join(", ", effectsQueue));
            }

            if (casingsStack.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(string.Join(", ", casingsStack));
            }

            Console.WriteLine($"Cherry Bombs: {cherryScore}");
            Console.WriteLine($"Datura Bombs: {daturaScore}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyScore}");
        }
    }
}
