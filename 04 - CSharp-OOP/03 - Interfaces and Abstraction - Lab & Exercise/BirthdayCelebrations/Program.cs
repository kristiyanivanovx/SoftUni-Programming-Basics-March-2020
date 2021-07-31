using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> birthDates = new List<string>();

            while (command != "End")
            {
                string[] arguments = command.Split(" ");

                //Citizen, Pet, Robot
                if (arguments[0] == "Citizen")
                {
                    // arguments[4]
                    birthDates.Add(arguments[4]);
                } 
                else if (arguments[0] == "Pet")
                {
                    // arguments[2]
                    birthDates.Add(arguments[2]);
                }

                command = Console.ReadLine();
            }

            string yearToCheck = Console.ReadLine();

            birthDates.ForEach((birthdate) =>
            {
                if (birthdate.EndsWith(yearToCheck))
                {
                    Console.WriteLine(birthdate);
                }
            });
        }
    }
}
