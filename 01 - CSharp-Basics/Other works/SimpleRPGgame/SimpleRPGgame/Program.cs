using System;

namespace SimpleRPGgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! ");
            string playerName = Console.ReadLine();
            Console.WriteLine($"Hello, {playerName}");

            //stats
            int playerHP = 100;
            int playerXP = 0;
            int playerLvl = 1;
            int playerAttack = 10;
            int playerCoins = 0;
            bool isAlive = true;
            int roomCount = 1;

            while (isAlive)
            {
                Console.WriteLine($"===== room {roomCount} =====");
                roomCount++;
                int roomType = new Random().Next(1, 5);
                switch (roomType)
                {
                    
                    case 1:
                    case 2:
                        Console.WriteLine("You've met a monster.");
                        int monsterAttack = 5;
                        int monsterHP = 20;

                        while (true)
                        {
                            Console.WriteLine("What do you do?");
                            Console.WriteLine("1 - Fight");
                            Console.WriteLine("2 - Escape");
                            int choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                // fight
                                while (true)
                                {
                                    monsterHP -= playerAttack;
                                    if (monsterHP < 0)
                                    {
                                        Console.WriteLine("You won");
                                        playerXP += 10;
                                        break;
                                    }
                                    playerHP -= monsterAttack;
                                    if (playerHP < 0)
                                    {
                                        isAlive = false;
                                        break;
                                    }
                                }
                            }
                            else if (choice == 2)
                            {

                            }
                        }
                        
                        if (playerHP < 0)
                        {
                            isAlive = false;
                        }
                        else
                        {
                            playerXP += 10;
                            if (playerXP > 100)
                            {
                                playerLvl++;
                                playerAttack += 10;
                                playerXP -= 100;
                            }
                        }
                        break;

                    case 3:
                        Console.WriteLine("You've found a chest.");
                        playerCoins += new Random().Next(15, 100);
                        //chest
                        break;

                    case 4:
                        Console.WriteLine("You've found a potion");
                        playerHP += 10;
                        // potion
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("Game over");
            Console.WriteLine($"Coins: {playerCoins}");
        }
    }
}
