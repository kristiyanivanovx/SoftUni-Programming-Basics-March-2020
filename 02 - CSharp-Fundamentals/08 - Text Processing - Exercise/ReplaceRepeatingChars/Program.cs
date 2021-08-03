using System;

namespace ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = string.Empty;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    if (output.Length == 0)
                    {
                        output += input[i];
                    }
                    else if (output[output.Length - 1] != input[i])
                    {
                        output += input[i];
                    }
                }
                else if (input[i + 1] != output[output.Length - 1])
                {
                    output += input[i + 1];

                }
                else if (output[output.Length - 1] != input[i])
                {
                    output += input[i];
                }
            }

            Console.WriteLine(output);
        }
    }
}
