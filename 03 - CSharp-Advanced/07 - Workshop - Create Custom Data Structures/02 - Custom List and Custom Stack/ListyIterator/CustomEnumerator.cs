using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class CustomEnumerator<T> : IEnumerator<T> 
        //where T : ListyIterator<T>
    {
        private List<T> internalEnumArr { get; set; }

        private int Count { get; set; }

        public CustomEnumerator(List<T> elements)
        {
            this.internalEnumArr = elements;
        }

        public T Current => internalEnumArr[Count++];

        object IEnumerator.Current => this.Current;

        public void Dispose() {}

        public bool MoveNext()
        {
            if (internalEnumArr.Count == Count)
            {
                return false;
            }

            return true;
        }

        public void Reset()
        {
            this.Count = -1;
        }
    }
}
