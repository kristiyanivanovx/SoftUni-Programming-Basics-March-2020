using System;

namespace SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < value.Length; i++)
            {
                sum += int.Parse(value[i].ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
