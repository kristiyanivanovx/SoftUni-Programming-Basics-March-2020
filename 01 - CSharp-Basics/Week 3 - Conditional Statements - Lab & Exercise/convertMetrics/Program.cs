using System;

namespace convertMetrics
{
    class Program
    {
        static void Main(string[] args)
        {
            // read value
            double value = double.Parse(Console.ReadLine());

            // read unitInput
            string unitInput = Console.ReadLine();

            // read unitOutput
            string unitOutput = Console.ReadLine();

            // convert
            double result = 0;
            if (unitInput == "mm")
            {
                if (unitOutput == "m")
                {
                    result = value / 1000;
                }
                else if (unitOutput == "cm")
                {
                    result = value / 10;
                }
                else if (unitOutput == "mm")
                {
                    result = value;
                }
            }
            else if (unitInput == "cm")
            {
                if (unitOutput == "m")
                {
                    result = value / 100;
                }
                else if (unitOutput == "cm")
                {
                    result = value;
                }
                else if (unitOutput == "mm")
                {
                    result = value * 10;
                }
            }
            else if (unitInput == "m")
            {
                if (unitOutput == "m")
                {
                    result = value;
                }
                else if (unitOutput == "cm")
                {
                    result = value * 100;
                }
                else if (unitOutput == "mm")
                {
                    result = value * 1000;
                }
            }

            // print

            Console.WriteLine($"{result:f3}");
        }
    }
}
