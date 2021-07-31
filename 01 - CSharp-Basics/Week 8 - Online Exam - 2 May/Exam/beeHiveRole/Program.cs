using System;

namespace beeHiveRole
{
    class Program
    {
        static void Main(string[] args)
        {
            int intelect = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            string role = "";

            if (intelect >= 80 && power >= 80 && gender == "female")
            {
                role = "Queen Bee";
            }
            else if (intelect >= 80)
            {
                role = "Repairing Bee";
            }
            else if (intelect >= 60)
            {
                role = "Cleaning Bee";
            }
            else if (power >= 80 && gender == "male")
            {

            }
            else if (power >= 60)
            {
                role = "Guard Bee";
            }
            else
            {
                role = "Worker Bee"; 
            }

            Console.WriteLine(role);
        }
    }
}
