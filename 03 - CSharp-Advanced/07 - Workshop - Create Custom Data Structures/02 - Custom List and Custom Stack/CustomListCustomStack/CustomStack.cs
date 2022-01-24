using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomListCustomStack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] internalStack;

        public int Count { get; private set; }

        public CustomStack()
        {
            this.internalStack = new T[InitialCapacity];
            this.Count = 0;
        }

        public void Push(T value) 
        {
            if (this.Count == this.internalStack.Length)
            {
                this.Resize();
            }

            this.internalStack[Count] = value;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack empty");
            }

            if (this.Count == this.internalStack.Length / 4)
            {
                this.Shrink();
            }

            T lastElement = this.internalStack[Count - 1];
            this.internalStack[Count - 1] = default;
            this.Count--;

            return lastElement;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack empty");
            }
            
            T lastElement = this.internalStack[this.Count - 1];
            return lastElement;
        }

        private void Shrink()
        {
            T[] copy = new T[internalStack.Length / 2];

            for (int element = 0; element < this.Count; element++)
            {
                copy[element] = this.internalStack[element];
            }

            this.internalStack = copy;
        }

        private void Resize()
        {
            T[] copy = new T[internalStack.Length * 2];

            for (int current = 0; current < internalStack.Length; current++)
            {
                copy[current] = internalStack[current];
            }

            this.internalStack = copy;
        }

        public void XSelect(Func<T, T> func)
        {
            for (int i = 0; i < this.Count; i++)
            {
                T element = this.internalStack[i];
                this.internalStack[i] = func(element);
            }
        }

        public void ForEach(Action<T> action)
        {
            int indexer = 0;
            foreach (var item in internalStack)
            {
                if (indexer != this.Count)
                {
                    action(item);
                    indexer++;
                }
                else
                {
                    break;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int indexer = 0;
            foreach (var item in internalStack)
            {
                if (indexer != this.Count)
                {
                    yield return item;
                    indexer++;
                }
                else
                {
                    break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
