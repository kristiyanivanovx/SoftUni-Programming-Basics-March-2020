using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    public class Node
    {
        public double Value { get; set; }

        public Node Next;

        public Node Previous;

        public Node(double value)
        {
            this.Value = value;
        }

        public void AddNext(Node nextNode)
        {
            this.Next = nextNode;
        }
    }
}
