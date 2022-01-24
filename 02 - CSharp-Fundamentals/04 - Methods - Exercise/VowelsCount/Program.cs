using System;
using System.Linq;

namespace VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = FindVowelsCount();
            Console.WriteLine(count);
        }

        private static int FindVowelsCount()
        {
            string value = Console.ReadLine();
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            int count = 0;

            for (int i = 0; i < value.Length; i++)
            {
                char current = value[i];
                if (vowels.Contains(current.ToString().ToLower().ToCharArray()[0]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
