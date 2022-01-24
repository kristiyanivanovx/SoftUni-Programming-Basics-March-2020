using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (!command.Contains("End"))
            {
                string type = command.Split().ElementAt(0);
                if (type == "Add")
                {
                    int number = int.Parse(command.Split().ElementAt(1));
                    list.Add(number);
                }
                else if (type == "Remove")
                {
                    int index = int.Parse(command.Split().ElementAt(1));

                    if (index >= 0 && index < list.Count)
                    {
                        list.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (type == "Shift")
                {
                    string direction = command.Split().ElementAt(1);
                    int count = int.Parse(command.Split().ElementAt(2));

                    if (direction == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int first = list[0];
                            list.RemoveAt(0);
                            list.Add(first);
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int last = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                            list.Insert(0, last);
                        }
                    }
                }
                else if (type == "Insert")
                {
                    int number = int.Parse(command.Split().ElementAt(1));
                    int index = int.Parse(command.Split().ElementAt(2));

                    if (index >= 0 && index < list.Count)
                    {
                        list.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
