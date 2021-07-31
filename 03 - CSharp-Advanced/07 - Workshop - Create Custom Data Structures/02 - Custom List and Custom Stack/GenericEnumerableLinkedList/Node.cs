using System;
using System.Collections.Generic;
using System.Text;

namespace GenericEnumerableLinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> Next;

        public Node<T> Previous;

        public Node(T value)
        {
            this.Value = value;
        }

        public void AddNext(Node<T> nextNode)
        {
            this.Next = nextNode;
        }
    }
}
