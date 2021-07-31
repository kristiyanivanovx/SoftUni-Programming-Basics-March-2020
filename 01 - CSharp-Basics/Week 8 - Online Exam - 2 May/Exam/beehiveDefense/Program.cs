using System;

namespace beehiveDefense
{
    class Program
    {
        static void Main(string[] args)
        {
            int beeCount = int.Parse(Console.ReadLine());
            int healthBear = int.Parse(Console.ReadLine());
            int damageBear = int.Parse(Console.ReadLine());

            bool isAliveBear = true;
            bool isWonBear = true;
            // every bee has 5 atk , 1 hp

            while (isAliveBear)
            {
                if ((damageBear - 100) >= beeCount)
                {
                    isWonBear = true;
                    beeCount = 0;
                    break;
                }
                beeCount -= damageBear;
                healthBear -= (beeCount * 5);

                if (healthBear <= 0)
                {
                    isAliveBear = false;
                    break;
                }
                if (beeCount <= 100 || beeCount <= 0)
                {
                    isWonBear = true;
                    break;
                }
            }

            if (isAliveBear || isWonBear)
            {
                Console.WriteLine($"The bear stole the honey! Bees left {beeCount}.");
            }
            else
            {
                Console.WriteLine($"Beehive won! Bees left {beeCount}.");
            }
        }
    }
}
