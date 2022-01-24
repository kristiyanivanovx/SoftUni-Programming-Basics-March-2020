using System;
using System.Collections.Generic;
using System.Text;

namespace GenericEnumerableLinkedList
{
    //public class GELLEnumerator<T> : IEnumerator<T> //where T : Node
    //{
    //    private Node<T>[] internalList { get; set; }
    //    //private CustomLinkedList<T> internalList { get; set; }

    //    public GELLEnumerator(Node<T> collection)
    //    {
    //        this.internalList =  collection;
    //    }

    //    private int Count { get; set; }

    //    public T Current => internalList[++Count];

    //    object IEnumerator.Current => this.Current;

    //    public void Dispose() { }

    //    public bool MoveNext()
    //    {
    //        if (Count == internalList.Length)
    //        {
    //            return false;
    //        }

    //        //Current = Current.Next;
    //        return true;
    //    }

    //    public void Reset()
    //    {
    //        this.Count = -1;
    //    }
    //}
}
