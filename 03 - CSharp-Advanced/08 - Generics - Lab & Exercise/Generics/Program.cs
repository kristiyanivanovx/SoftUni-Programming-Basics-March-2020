using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<string> cll = new CustomLinkedList<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                cll.AddLast(new Node<string>(input));
            }

            cll.ForeachFromHead(s => Console.WriteLine(s.Value));
        } 
    }
}
