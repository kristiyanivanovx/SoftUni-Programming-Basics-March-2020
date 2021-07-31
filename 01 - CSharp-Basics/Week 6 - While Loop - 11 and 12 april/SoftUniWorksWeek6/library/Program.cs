using System;

namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int booksCount = int.Parse(Console.ReadLine());
            int checkedCount = 0;
            bool isFound = false;

            while (!isFound)
            {
                string currBook = Console.ReadLine();
                if (currBook == book)
                {
                    isFound = true;
                }
                else
                {
                    checkedCount++;
                    if (checkedCount >= booksCount)
                    {
                        break;
                    }
                }
            }

            if (isFound)
            {
                Console.WriteLine($"You checked {checkedCount} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!{Environment.NewLine}You checked {checkedCount} books.");
            }
        }
    }
}