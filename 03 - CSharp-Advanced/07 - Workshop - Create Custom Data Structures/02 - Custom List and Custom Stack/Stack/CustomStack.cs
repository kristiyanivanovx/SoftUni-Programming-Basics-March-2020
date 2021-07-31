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
                internalStack.Add(item);
                index++;
            }
        }

        public T Pop()
        {
            if (index == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
                //throw new InvalidOperationException("No elements");
            }
            else
            {
                T toBeReturned = internalStack[index - 1];
                this.internalStack[index - 1] = default(T);
                index--;
                return toBeReturned;
            }

            //try
            //{
            //    T toBeReturned = internalStack[index - 1];
            //    this.internalStack[index - 1] = default(T);
            //    index--;
            //    return toBeReturned;
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("No elements");
            //    //throw;
            //}
            //return default(T);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = internalStack.Count - 1; i >= 0; i--)
            {
                yield return internalStack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
