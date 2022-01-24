using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 7 8 2 5 4 7 8 9 6 3 2 5 4 6
            //20

            //5

            //5 4 8 6 3 8 7 7 9
            //16

            //5

            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesInBox);

            int capacityOfRack = int.Parse(Console.ReadLine());
            int currentRackCapacity = capacityOfRack;
            int racksCount = 1;

            while (clothes.Any())
            {
                int cloth = clothes.Pop();
                currentRackCapacity -= cloth;

                if (currentRackCapacity < 0)
                {
                    racksCount += 1;
                    currentRackCapacity = capacityOfRack - cloth;
                }
            }

            //for (int i = 0; i < clothesInBox.Length; i++)
            //{
            //    if ((capacityOfRack - clothes.Sum()) >= clothesInBox[i])
            //    {
            //        //capacityOfRack = 0;
            //        //stack.Clear();
            //        //rackCount += 1;
            //        clothes.Push(clothesInBox[i]);
            //    }
            //    else
            //    {
            //        clothes.Clear();
            //        rackCount += 1;
            //    }
            //}

            Console.WriteLine(racksCount);
        }
    }
}
