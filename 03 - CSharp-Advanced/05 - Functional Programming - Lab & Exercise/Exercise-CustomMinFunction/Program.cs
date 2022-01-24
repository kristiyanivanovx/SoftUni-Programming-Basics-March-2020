using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<List<int>, int> customMinFunction = (list) => list.Min();
            Console.WriteLine(customMinFunction(numbers));
        }
    }
}
