using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericEnumerableLinkedList
{
    public class CustomLinkedList<T> : IEnumerable
    {
        private int count = 0;

        public Node<T> Head { get; set; }

        public Node<T> Tail { get; set; }

        //public CustomLinkedList(Node<T> node)
        //{
        //    this.Head = node;
        //    this.Tail = node;
        //}

        public void AddHead(Node<T> node)
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

        public void AddTail(Node<T> node)
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

        public Node<T> RemoveHead()
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

        public Node<T> RemoveTail()
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

        public void ForEachFromHead(Action<Node<T>> action)
        {
            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public void ForEachFromTail(Action<Node<T>> action)
        {
            Node<T> currentNode = Tail;

            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        public T[] ToArray()
        {
            int index = 0;
            T[] array = new T[count];

            Node<T> currentNode = Head;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.Next;

                if (index == count)
                {
                    break;
                }

                index += 1;
            }

            return array;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            //return new GELLEnumerator<Node<T>>(collection);
            //T[] collection = this.ToArray();

            foreach (T node in this.ToArray())
            {
                yield return new Node<T>(node);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
