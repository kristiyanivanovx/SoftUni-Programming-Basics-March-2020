using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            int intelligence = int.Parse(Console.ReadLine());

            int bulletsUsedCount = 0;
            int currGunBarrelSize = sizeGunBarrel;

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            while (bullets.Any() && locks.Any())
            {
                bulletsUsedCount += 1;
                currGunBarrelSize -= 1;

                var currentBullet = bullets.Pop();
                var currentLock = locks.Peek();
                
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currGunBarrelSize == 0 && bullets.Any())
                {
                    currGunBarrelSize = sizeGunBarrel;
                    Console.WriteLine("Reloading!");
                }
            }

            if (!locks.Any())
            {
                int moneyEarned = intelligence - (bulletsUsedCount * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
