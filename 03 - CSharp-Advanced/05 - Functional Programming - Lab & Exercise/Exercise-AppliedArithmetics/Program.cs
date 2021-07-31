using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 3 4 5
            //add
            //add
            //print
            //end

            //3 4 5 6 7

            //5 10
            //multiply
            //subtract
            //print
            //end

            //9 19

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Action<List<int>> printer = nums => Console.WriteLine(string.Join(" ", nums));
            
            Func<int, int> arithmetics = (number) => number;

            while (command != "end")
            {
                if (command == "add")
                {
                    arithmetics = num => num + 1;
                }
                else if (command == "multiply")
                {
                    arithmetics = num => num * 2;
                }
                else if (command == "subtract")
                {
                    arithmetics = num => num - 1;
                }
                else if (command == "print")
                {
                    printer(numbers);
                }

                numbers = numbers.Select(arithmetics).ToList();
                command = Console.ReadLine();
            }
        }
    }
}
