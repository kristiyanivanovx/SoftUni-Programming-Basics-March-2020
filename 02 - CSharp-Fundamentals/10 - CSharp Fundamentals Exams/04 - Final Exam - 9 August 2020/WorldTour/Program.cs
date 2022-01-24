using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while (!command.Contains("Travel"))
            {
                string[] data = command.Split(":");
                string type = data[0];
                if (type == "Add Stop")
                {
                    int index = int.Parse(data[1]);
                    string toBeInserted = data[2];

                    if (index < input.Length)
                    {
                        input = input.Insert(index, toBeInserted);
                    }
                }
                else if (type == "Remove Stop")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    if (startIndex < input.Length && endIndex < input.Length)
                    {
                        input = input.Remove(startIndex, endIndex - startIndex + 1);
                    }
                }
                else if (type == "Switch")
                {
                    string oldString = data[1];
                    string newString = data[2];

                    if (input.Contains(oldString))
                    {
                        input = input.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(input);
                command = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}
