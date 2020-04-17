﻿using System;

namespace fruits
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;
            bool isValid = true;

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wenesday":
                case "Thursday":
                case "Friday":
                    switch (fruit)
                    {
                        case "apple":
                            price = 1.2;
                            break;
                        case "banana":
                            price = 2.5;
                            break;
                        case "orange":
                            price = 0.85;
                            break;
                        case "grapefruit":
                            price = 1.45;
                            break;
                        case "kiwi":
                            price = 2.7;
                            break;
                        case "pineapple":
                            price = 5.5;
                            break;
                        case "grapes":
                            price = 3.85;
                            break;

                        default :
                            isValid = false;
                            break;

                    }
                    break;

                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "apple":
                            price = 1.25;
                            break;
                        case "banana":
                            price = 2.7;
                            break;
                        case "orange":
                            price = 0.90;
                            break;
                        case "grapefruit":
                            price = 1.6;
                            break;
                        case "kiwi":
                            price = 3;
                            break;
                        case "pineapple":
                            price = 5.6;
                            break;
                        case "grapes":
                            price = 4.2;
                            break;
                        default:
                            isValid = false;
                            break;
                    }
                    break;

                default:
                    isValid = false;
                    break;
            }
            if (isValid)
            {
                Console.WriteLine($"{price * quantity:f2}");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
