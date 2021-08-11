using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int tosses = int.Parse(Console.ReadLine());
            int current = 0;
            Queue<string> kids = new Queue<string>(input);

            while (kids.Count > 1)
            {
                current += 1;
                string removedKid = kids.Dequeue();

                if (current == tosses)
                {
                    Console.WriteLine("Removed " + removedKid);
                    current = 0;
                }
                else
                {
                    kids.Enqueue(removedKid);
                }
            }

            Console.WriteLine("Last is " + kids.Dequeue());
        }
    }
}
