using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // stacks

            //3 5 8 4 1 9
            //add 19 32
            //remove 10
            //add 89 22
            //remove 4
            //remove 3
            //end
            //sum: 16

            //1 2 3 4
            //adD 5 6
            //REmove 3
            //end
            //sum: 6

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);

            string command = Console.ReadLine().ToLower();

            while (command != "end")
            {
                if (command.Contains("add"))
                {
                    var splitted = command.Split();
                    stack.Push(int.Parse(splitted[1]));
                    stack.Push(int.Parse(splitted[2]));
                }
                else if (command.Contains("remove"))
                {
                    var splitted = command.Split();
                    var count = int.Parse(splitted[1]);

                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Sum: " + stack.Sum());
        }
    }
}
