using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class TupleCustom<T1, T2>
    {
        private T1 first;

        private T2 second;

        public T1 First { get; private set; }

        public T2 Second { get; private set; }

        public TupleCustom(T1 first, T2 second)
        {
            this.First = first;
            this.Second = second;
        }
    }

    public class TupleCustom<T1, T2, T3>
    {
        private T1 first;

        private T2 second;

        private T3 third;

        public T1 First { get; private set; }

        public T2 Second { get; private set; }

        public T3 Third { get; private set; }

        public TupleCustom(T1 first, T2 second, T3 third)
        {
            this.First = first;
            this.Second = second;
            this.Third = third;
        }
    }
}
