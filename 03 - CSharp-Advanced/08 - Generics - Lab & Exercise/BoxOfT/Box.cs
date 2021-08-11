using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> BaseStack;

        public int Count => BaseStack.Count;

        public Box()
        {
            this.BaseStack = new Stack<T>();
        }

        public void Add(T element)
        {
            this.BaseStack.Push(element);
        }

        public T Remove()
        {
            return this.BaseStack.Pop();
        }
    }
}
