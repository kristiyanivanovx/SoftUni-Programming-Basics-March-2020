using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string group = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;

            if (group == "Students")
            {
                if (day == "Friday")
                {
                    price = count * 8.45;
                }
                else if (day == "Saturday")
                {
                    price = count * 9.80;
                }
                else if (day == "Sunday")
                {
                    price = count * 10.46;
                }

                if (count >= 30)
                {
                    price -= price * 0.15;
                }
            }
            else if (group == "Business")
            {
                if (day == "Friday")
                {
                    if (count >= 100)
                    {
                        price = (count - 10) * 10.90;
                    }
                    else
                    {
                        price = count * 10.90;
                    }
                }
                else if (day == "Saturday")
                {
                    if (count >= 100)
                    {
                        price = (count - 10) * 15.60;

                    }
                    else
                    {
                        price = count * 15.60;
                    }
                }
                else if (day == "Sunday")
                {
                    if (count >= 100)
                    {
                        price = (count - 10) * 16;
                    }
                    else
                    {
                        price = count * 16;
                    }
                }
            }
            else if (group == "Regular")
            {
                if (day == "Friday")
                {
                    price = count * 15;
                }
                else if (day == "Saturday")
                {
                    price = count * 20;
                }
                else if (day == "Sunday")
                {
                    price = count * 22.50;
                }

                if (count >= 10 && 20 >= count)
                {
                    price -= price * 0.05;
                }
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
