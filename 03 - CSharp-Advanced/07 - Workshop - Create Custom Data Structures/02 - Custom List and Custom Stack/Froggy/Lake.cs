using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable
    {
        private List<int> stonesUnsorted;

        //public Queue<int> stonesSorted;

        //private Stack<int> stonesHelper;

        public Lake(params int[] stonesInput)
        {
            this.stonesUnsorted = new List<int>(stonesInput);
            //this.stonesSorted = new Queue<int>();
            //this.stonesHelper = new Stack<int>();
        }

        //public void SortStones()
        //{
        //    int lengthUnsorted = stonesUnsorted.Count - 1;
        //    //var smallest = stonesUnsorted.Min();
        //    var smallest =  stonesUnsorted.Dequeue();
        //    this.stonesSorted.Enqueue(smallest);
        //    for (int current = 0; current < lengthUnsorted; current++)
        //    {
        //        var currentElement = stonesUnsorted.Dequeue();
        //        if (currentElement % 2 == 0)
        //        {
        //            stonesHelper.Push(currentElement);
        //            //if (currentElement == 4)
        //            //{
        //            //    stonesSorted.Enqueue(currentElement);
        //            //}
        //            //else
        //            //{
        //            //    stonesHelper.Push(currentElement);
        //            //}
        //        }
        //        else if (currentElement % 2 == 1 || currentElement == 1)
        //        {
        //            if (currentElement == 23 || currentElement == 9)
        //            {
        //                stonesHelper.Push(currentElement);
        //            }
        //            else
        //            {
        //                stonesSorted.Enqueue(currentElement);
        //            }
        //        }
        //        //stonesUnsorted.Enqueue(current);
        //    }
        //    int lengthStones = stonesHelper.Count;
        //    for (int current = 0; current < lengthStones; current++)
        //    {
        //        var currentElement = stonesHelper.Pop();
        //        stonesSorted.Enqueue(currentElement);
        //    }
        //}

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < stonesUnsorted.Count - 1; i += 1)
            {
                yield return stonesUnsorted[i];
                stonesUnsorted.Remove(stonesUnsorted[i]);
            }

            for (int i = stonesUnsorted.Count - 1; i >= 0; i -= 1)
            {
                yield return stonesUnsorted[i];
                stonesUnsorted.Remove(stonesUnsorted[i]);
            }

            //foreach (int item in stonesUnsorted)
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
