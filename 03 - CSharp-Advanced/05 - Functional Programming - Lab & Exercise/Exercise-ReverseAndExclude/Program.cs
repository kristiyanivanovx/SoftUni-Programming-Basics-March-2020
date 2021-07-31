using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5 6
            //2

            //531

            //20 10 40 30 60 50
            //3

            //50 40 10 20

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            Predicate<int> predicate = (number) => number % n != 0;

            numbers = numbers.Where(n => predicate(n)).ToList();
            numbers.Reverse();

            Console.Write(string.Join(" ", numbers));
        }
    }
}
