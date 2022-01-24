using System;

namespace GenericEnumerableLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<double> list = new CustomLinkedList<double>();

            for (int i = 0; i < 10; i++)
            {
                list.AddTail(new Node<double>(i * 2));
            }

            foreach (var item in list)
            {
                Console.Write("in the foreach: ");
                Console.WriteLine(item.Value);
            }

            //list.ForEachFromHead((node) => Console.WriteLine(node.Value));

            //Console.WriteLine("-------------------");

            //list.ForEachFromHead((node) => Console.WriteLine(node.Value));

            //Console.WriteLine("ForEachFromTail");
            //list.ForEachFromTail((currentNode) => Function(currentNode));

            //Console.WriteLine("ForEachFromHead");
            //list.ForEachFromHead((currentNode) => Function(currentNode));

            //int[] linkedListAsArray = list.ToArray();
        }

        //public static void Function(Node<T> currentNode)
        //{
        //    double result = currentNode.Value *= 5;
        //    Console.WriteLine(result);
        //}
    }
}
