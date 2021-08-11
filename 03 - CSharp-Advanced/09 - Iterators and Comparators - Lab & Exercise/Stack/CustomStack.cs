using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> internalStack;

        private int index;

        public CustomStack()
        {
            this.internalStack = new List<T>();
        }

        public void Push(IEnumerable<T> elements) 
        {
            foreach (T item in elements)
            {
                this.internalStack.Add(item);
                this.index++;
            }
        }

        public T Pop()
        {
            if (this.index == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            else
            {
                T lastElement = this.internalStack[this.index - 1];
                this.internalStack[this.index - 1] = default(T);
                this.index--;

                return lastElement;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.internalStack.Count - 1; i >= 0; i--)
            {
                yield return this.internalStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
