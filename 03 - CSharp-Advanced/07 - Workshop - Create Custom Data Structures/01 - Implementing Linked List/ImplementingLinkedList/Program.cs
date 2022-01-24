using System;

namespace ImplementingLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);

            head.Next = node2;
            node2.Next = node3;
            node3.Next = node4;

            Node current = head;

            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}
