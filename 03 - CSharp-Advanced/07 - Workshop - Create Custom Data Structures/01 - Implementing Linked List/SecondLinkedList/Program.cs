using ImplementingLinkedList;
using System;

namespace SecondLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedListFastReverse list = new CustomLinkedListFastReverse();

            for (int i = 0; i < 10; i++)
            {
                list.AddTail(new Node(i * 2));
            }

            list.Reverse();
            list.ForEachFromHead((node) => Console.WriteLine(node.Value));

            Console.WriteLine("-------------------");

            list.Reverse();
            list.ForEachFromHead((node) => Console.WriteLine(node.Value));

            return;
            CustomLinkedList cll = new CustomLinkedList();

            for (int i = 0; i < 20; i++)
            {
                //cll.AddHead(new Node(i));
                cll.AddTail(new Node(i));
            }

            //Console.WriteLine(cll.RemoveHead().Value);

            var currNode = cll.Head;
            //var currNode = cll.Tail;

            while (currNode != null)
            {
                Console.WriteLine(currNode.Value);
                //currNode = currNode.Next;
                currNode = currNode.Next;
            }

            Console.WriteLine("ForEachFromTail");
            cll.ForEachFromTail((currentNode) => Function(currentNode));

            Console.WriteLine("ForEachFromHead");
            cll.ForEachFromHead((currentNode) => Function(currentNode));

            int[] linkedListAsArray = cll.ToArray();
        }

        public static void Function(Node currentNode)
        {
            double result = currentNode.Value *= 5;
            Console.WriteLine(result);
        }
    }
}
