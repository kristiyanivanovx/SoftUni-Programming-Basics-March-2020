using System;
using System.Collections.Generic;
using System.Linq;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while (!command.Contains("end"))
            {
                var data = command.Split();
                if (data[0] == "Add")
                {
                    int wagon = int.Parse(data[1]);
                    train.Add(wagon);
                }
                else
                {
                    int passengers = int.Parse(data[0]);
                    for (int i = 0; i < train.Count; i++)
                    {
                        if (train[i] + passengers <= maxCapacity)
                        {
                            train[i] += passengers;
                            break;
                        } 
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
