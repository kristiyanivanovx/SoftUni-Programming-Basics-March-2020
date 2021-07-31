using ImplementingLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondLinkedList
{
    public class CustomLinkedList
    {
        private int count = 0;

        public Node Head { get; set; }

        public Node Tail { get; set; }

        public void AddHead(Node node)
        {
            count += 1;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddTail(Node node)
        {
            count += 1;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public Node RemoveHead() 
        {
            if (Head == null)
            {
                return null;
            }

            count -= 1;

            var nodeToReturn = Head;

            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return nodeToReturn;
        }

        public Node RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }

            count -= 1;

            var nodeToReturn = Tail;

            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Tail = null;
                Head = null;
            }

            return nodeToReturn;
        }

        public void ForEachFromHead(Action<Node> action)
        {
            Node currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public void ForEachFromTail(Action<Node> action)
        {
            Node currentNode = Tail;

            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        public int[] ToArray()
        {
            int index = 0;
            int[] array = new int[count];

            Node currentNode = Head;

            while (currentNode != null)
            {
                array[index] = (int) currentNode.Value;
                currentNode = currentNode.Next;
                index += 1;
            }

            return array;
        }
    }
}
