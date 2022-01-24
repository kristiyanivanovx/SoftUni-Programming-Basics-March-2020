using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] threads = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int valueOfTaskToBeKilled = int.Parse(Console.ReadLine());

            Stack<int> tasksStack = new Stack<int>(tasks);
            Queue<int> threadsQueue = new Queue<int>(threads);

            while (tasksStack.Any() && threadsQueue.Any())
            {
                var currentTask = tasksStack.Peek();
                var currentThread = threadsQueue.Peek();

                if (currentThread >= currentTask)
                {
                    var taskRemoved = tasksStack.Pop();
                    var threadKiller = threadsQueue.Peek();

                    if (taskRemoved == valueOfTaskToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {threadKiller} killed task {taskRemoved}");

                        //Console.WriteLine(threadKiller);

                        Console.WriteLine(string.Join(" ", threadsQueue));

                        break;
                    }
                    threadsQueue.Dequeue();

                }
                else if (currentThread < currentTask)
                {
                    if (currentTask == valueOfTaskToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");

                        //Console.Write(currentThread);
                        Console.WriteLine(string.Join(" ", threadsQueue));
                        //var threadKiller = threadsQueue.Dequeue();

                        break;
                    }

                    threadsQueue.Dequeue();
                }


            }
        }
    }
}
