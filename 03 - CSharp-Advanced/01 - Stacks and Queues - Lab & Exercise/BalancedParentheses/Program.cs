using System;
using System.Collections.Generic;

namespace BalancedParentheses
{
    // {[()]}        YES
    // {{[[(())]]}}  YES
    // {[(])}        NO
    // {([]]}        NO
    // [({}))        NO

    class StartUp
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool balanced = false;

            foreach (char item in expression)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    parentheses.Push(item);
                }
                else if (item == ')' || item == '}' || item == ']')
                {
                    string both = parentheses.Pop().ToString() + item;

                    if ((both != "[]") && (both != "{}") && (both != "()"))
                    {
                        balanced = false;
                        break;
                    }
                    else
                    {
                        balanced = true;
                    }
                }
            }

            if (balanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
