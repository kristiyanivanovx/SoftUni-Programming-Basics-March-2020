using System;

namespace cleverLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            //for l to age
            //for 1 to age
            //if odd toys ++
            //if even money => money += 10;
            //brother effect!
            //sell toys
            // check if savings are enough

            int age = int.Parse(Console.ReadLine());
            double priceLaundryMachine = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            double savings = 0;
            double toysCount = 0;
            double money = 10;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savings += money;
                    savings -= 1;
                    money += 10;
                }
                else
                {
                    toysCount++;

                }

            }

            savings += toysCount * toyPrice;

            if (savings >= priceLaundryMachine)
            {
                double remainder = savings - priceLaundryMachine;
                Console.WriteLine($"Yes! {remainder:f2}");
            }
            else
            {
                double diff = priceLaundryMachine - savings;
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
