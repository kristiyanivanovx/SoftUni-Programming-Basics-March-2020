using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            //3
            //2
            //-1
            //2

            //2

            //5
            //1
            //2
            //3
            //1
            //5

            //1

            // <element, times faced>
            int elementsCount = int.Parse(Console.ReadLine());
            Dictionary<int, int> elements = new Dictionary<int, int>();

            for (int i = 0; i < elementsCount; i++)
            {
                int element = int.Parse(Console.ReadLine());
                if (elements.ContainsKey(element))
                {
                    elements[element] += 1;
                }
                else
                {
                    elements.Add(element, 1);
                }
            }

            foreach (var el in elements)
            {
                if (el.Value % 2 == 0)
                {
                    Console.WriteLine(el.Key);
                }
            }
        }
    }
}
