using System;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Dictionary<double, int> sameValues = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
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
