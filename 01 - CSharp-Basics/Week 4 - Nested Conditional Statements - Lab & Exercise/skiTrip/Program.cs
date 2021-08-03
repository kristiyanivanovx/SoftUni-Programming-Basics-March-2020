using System;

namespace skiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            // read
            int days = int.Parse(Console.ReadLine());
            //0
            if (days > 0)
            {
                days -= 1;
            }
             
            string roomType = Console.ReadLine();
            string feedback = Console.ReadLine();

            // nb 0 days
            // calculate price
            double price = 0;

            if (roomType == "room for one person")
            {
                price = 18;
            }
            else if (roomType == "apartment")
            {
                price = 25;
            }
            else
            {
                price = 35;
            }
            // check discount: calculate total first?
            switch (roomType)
            {
                case "apartment":
                    if (days < 10)
                    {
                        price = price * 0.70;

                    }
                    else if (days <= 15)
                    {
                        price *= 0.65;
                    }
                    else
                    {
                        price *= 0.5;
                    }
                    break;

                case "president apartment":
                    if (days < 10)
                    {
                        price = price * 0.90;

                    }
                    else if (days <= 15)
                    {
                        price *= 0.85;
                    }
                    else
                    {
                        price *= 0.80;
                    }
                    break;
            }
            // calc total price
            double totalPrice = (price * days);

            //check tip?

            if (feedback == "positive")
            {
                totalPrice *= 1.25;
            }
            else
            {
                totalPrice *= 0.90;
            }
            // print
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
