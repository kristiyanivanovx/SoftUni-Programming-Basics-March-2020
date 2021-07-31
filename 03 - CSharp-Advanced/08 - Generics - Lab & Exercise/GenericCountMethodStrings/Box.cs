using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T> 
        // where T : IComparable
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }

        //public int CompareTo(T other)
        //{
        //    int some = this.Value.CompareTo(other);
        //    return some; 
        //}
    }
}
