using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public int Count { get; private set; }

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        public void Foreach(Action<T> action)
        {
            Node<T> currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public void ForeachFromTail(Action<Node<T>> action)
        {
            Node<T> currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        // AddHead
        public void AddFirst(T element)
        {
            Node<T> node = new Node<T>(element);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Previous = node;
                Head = node;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            Node<T> node = new Node<T>(element);

            if (Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        // RemoveHead
        public T RemoveFirst()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("The list is empty");
                // return null
            }

            var headValue = Head.Value;
            Head = Head.Next;

            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }

            Count--;
            return headValue;
        }

        // RemoveTail
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var tailValue = Tail.Value;
            Tail = Tail.Previous;

            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }

            Count--;
            return tailValue;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T> currentNode = this.Head;
            int counter = 0;

            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }

            return array;
        }
    }
}
