using System;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    // dictionaries

    class Program
    {
        static void Main(string[] args)
        {
            //-2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3

            //-2.5 - 3 times
            //4 - 2 times
            //3 - 4 times
            //- 5.5 - 1 times

            //2 4 4 5 5 2 3 3 4 4 3 3 4 3 5 3 2 5 4 3

            //2 - 3 times
            //4 - 6 times
            //5 - 4 times
            //3 - 7 times

            string[] input = Console.ReadLine().Split();
            Dictionary<double, int> sameValues = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                //double value = double.Parse(input[i]);
                double value = double.Parse(input[i], System.Globalization.CultureInfo.InvariantCulture);

                if (sameValues.ContainsKey(value))
                {
                    sameValues[value] += 1;
                }
                else
                {
                    sameValues.Add(value, 1);
                }
            }

            foreach (var item in sameValues)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
