using System;
using System.Linq;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            while (!value.Contains("END"))
            {
                Console.WriteLine(IsPalindrome(value).ToString().ToLower());
                value = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string value)
        {
            string reversed = new string(value.Reverse().ToArray());
            return reversed == value;
        }
    }
}
