using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class CustomEnumerator<T> : IEnumerator<T>
        //where T : ListyIterator<T>
    {
        private T[] internalArray { get; set; }

        private int Count { get; set; }

        public T Current => this.internalArray[this.Count++];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        { }

        public bool MoveNext()
        {
            return this.internalArray.Length == this.Count;
        }

        public void Reset()
        {
            this.Count = -1;
        }
    }
}
