using System;

namespace savings
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double sumPrivate = double.Parse(Console.ReadLine());

            double sumUnexpected = 0.3 * income;
            double savedMoneyPerMonth = income - sumPrivate - sumUnexpected;

            double totalMoney = months * savedMoneyPerMonth;
            double percent = savedMoneyPerMonth / income * 100;

            Console.WriteLine($"She can save {percent:f2}%");
            Console.WriteLine($"{totalMoney:f2}");
        }
    }
}
