using System;
using System.Collections.Generic;

namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> market = new Queue<string>();
            int counter = 0;

            while (input.ToLower() != "end")
            {
                if (input.ToLower() == "paid")
                {
                    for (int j = 0; j <= market.Count; j++)
                    {
                        if (market.Count > 0)
                        {
                            Console.WriteLine(market.Dequeue());
                            counter -= 1;
                        }
                    }

                    counter -= 1;
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

        /**
        - input --
        Amelia
        Thomas
        Elias
        End

        - output --
        3 people remaining.

        - input --
        Liam
        Noah
        James
        Paid
        Oliver
        Lucas
        Logan
        Tiana
        End

        - output --
        Liam
        Noah
        James
        4 people remaining.
        **/
    }
}
