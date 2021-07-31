using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : struct
    {
        private T Left;
        private T Right;

        public EqualityScale(T left, T right)
        {
            Left = left;
            Right = right;
        }

        public bool AreEqual()
        {
            if (Left.Equals(Right))
            {
                return true;
            }

            return false;
        }
    }
}
