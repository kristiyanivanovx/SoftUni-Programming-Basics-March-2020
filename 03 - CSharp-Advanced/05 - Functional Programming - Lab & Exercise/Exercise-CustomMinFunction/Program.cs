using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = "1 4 3 2 1 7 13 0 -20".Split().Select(int.Parse).ToList();
            
            Func<List<int>, int> customMinFunction = (list) => list.Min();
            
            Console.WriteLine(customMinFunction(numbers));

            //for (int i = 0; i < numbers.Count - 1; i++)
            //{
            //    if (numbers[i] < numbers[i + 1])
            //    {
            //        continue;
            //    }

            //    Console.WriteLine(numbers[i]);
            //}
        }
    }
}
