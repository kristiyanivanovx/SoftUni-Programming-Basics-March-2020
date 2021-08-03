using System;
using System.Linq;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string data =  Console.ReadLine();

            string output = string.Empty;
            data.ToCharArray().ToList().ForEach(x =>
            {
                output += (char)(x + 3);
            });

            Console.WriteLine(output);
        }
    }
}
