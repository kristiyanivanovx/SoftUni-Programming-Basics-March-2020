using System;
using System.Collections.Generic;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string input = Console.ReadLine();
            Queue<string> market = new Queue<string>();

            while (!input.ToLower().Contains("end"))
            {
                if (input.ToLower().Contains("paid"))
                {
                    int marketCount = market.Count;
                    for (int i = 0; i <= marketCount; i++)
                    {
                        if (market.Count > 0)
                        {
                            Console.WriteLine(market.Dequeue());
                            counter -= 1;
                        }
                    }
                }
                else
                {
                    market.Enqueue(input);
                    counter += 1;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(counter + " people remaining.");

        }
    }
}
