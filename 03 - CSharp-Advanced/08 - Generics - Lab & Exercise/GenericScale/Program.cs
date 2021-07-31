using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = 1;
            int r = 2;

            EqualityScale<int> eqs = new EqualityScale<int>(l, r);
            Console.WriteLine(eqs.AreEqual()); // false

            int l2 = 5;
            int r2 = 5;

            EqualityScale<int> eqs2 = new EqualityScale<int>(l2, r2);
            Console.WriteLine(eqs2.AreEqual()); // true
        }
    }
}
