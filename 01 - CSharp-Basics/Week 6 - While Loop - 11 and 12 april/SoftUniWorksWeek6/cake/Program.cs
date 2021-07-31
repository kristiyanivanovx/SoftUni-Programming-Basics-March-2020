using System;

namespace cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakeSize = width * length;
            bool isNoMore = false;

            int difference = 0;
            int pieces = 0;
            string command = Console.ReadLine();

            while (command != "STOP")
            {
                int piece = int.Parse(command);
                pieces += piece;

                if (pieces > cakeSize)
                {
                    isNoMore = true;
                    break;
                }
                command = Console.ReadLine();
            }
            if (command == "STOP")
            {
                difference = cakeSize - pieces;
                Console.WriteLine($"{difference} pieces are left.");
            }
            if (isNoMore)
            {
                difference = pieces - cakeSize;
                Console.WriteLine($"No more cake left! You need {difference} pieces more.");
            }
        }
    }
}