using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> playerTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            int current = 0;
            while (playerOne.Any() && playerTwo.Any())
            {
                if (playerOne[current] > playerTwo[current])
                {
                    int cardOne = playerOne[current];
                    int cardTwo = playerTwo[current];

                    playerOne.RemoveAt(current);
                    playerTwo.RemoveAt(current);

                    playerOne.AddRange(new int[] { cardOne, cardTwo });
                }
                else if (playerOne[current] == playerTwo[current])
                {
                    playerOne.RemoveAt(current);
                    playerTwo.RemoveAt(current);
                }
                else if (playerOne[current] < playerTwo[current])
                {
                    int cardOne = playerOne[current];
                    int cardTwo = playerTwo[current];

                    playerOne.RemoveAt(current);
                    playerTwo.RemoveAt(current);

                    playerTwo.AddRange(new int[] { cardTwo, cardOne });
                }
            }

            if (playerOne.Any())
            {
                Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }
        }
    }
}
