using System;

namespace salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numTabs; i++)
            {
                string tab = Console.ReadLine();

                switch (tab)
                {
                    case "Facebook":
                        salary -= 150;
                        break;

                    case "Instagram":
                        salary -= 100;
                        break;

                    case "Reddit":
                        salary -= 50;
                        break;

                    default:
                        break;
                }

                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine(salary);
            }
        }
    }
}
