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

        public int index { get; set; }

        public ListyIterator(params T[] collection)
        {
            this.index = 0;
            this.internalList = collection.ToList();
        }

        public void Create(params T[] collection)
        {
            this.internalList = new List<T>(collection);
        }

        //public void Create(params IEnumerable<T>[] collection)
        //{
        //    this.internalList = new List<T>();
        //    if (collection.Any())
        //    {
        //        foreach (var items in collection)
        //        {
        //            foreach (var subitem in items)
        //            {
        //                if (subitem.Equals("Create"))
        //                {
        //                    continue;
        //                }
        //                internalList.Add(subitem);
        //            }
        //        }
        //    }
        //}

        public bool Move()
        {
            //if (internalList[index + 1] == null)
            if (internalList.Count == index + 1)
            {
                return false;
            }

            index++;
            return true;
        }

        public bool HasNext()
        {
            // this.index < this.items.Count - 1
            if (internalList.Count == index + 1)
            {
                return false;
            }

            return true;
        }

        public void Print() 
        {
            if (internalList.Count == 0)
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
            Console.WriteLine(string.Join(" ", internalList));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>(internalList);

            //foreach (T item in internalList)
            //{
            //    yield return item;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
