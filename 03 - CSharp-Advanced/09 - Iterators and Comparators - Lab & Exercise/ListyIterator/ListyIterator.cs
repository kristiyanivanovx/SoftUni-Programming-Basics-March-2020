using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> internalList;

        private int index { get; set; }

        public ListyIterator(params T[] collection)
        {
            this.index = 0;
            this.internalList = collection.ToList();
        }

        public void Create(params T[] collection)
        {
            this.internalList = new List<T>(collection);
        }

        public bool Move()
        {
            if (this.internalList.Count == this.index + 1)
            {
                return false;
            }

            this.index++;
            return true;
        }

        public bool HasNext()
        {
            return this.internalList.Count != this.index + 1;
        }

        public void Print() 
        {
            if (this.internalList.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(internalList[index]);
            }
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.internalList));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
