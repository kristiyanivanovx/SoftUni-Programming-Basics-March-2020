using System;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();

            string input = Console.ReadLine();
            while (input == "end")
            {
                doublyLinkedList.AddLast(input);
                input = Console.ReadLine();
            }

            doublyLinkedList.Foreach(s => Console.WriteLine(s));
        } 
    }
}