using System;

namespace GenericScale
{
    class Program
    {
        static void Main(string[] args)
        {
            int left = 1;
            int right = 2;

            EqualityScale<int> equalityScale = new EqualityScale<int>(left, right);
            Console.WriteLine(equalityScale.AreEqual()); // false

            int leftTwo = 5;
            int rightTwo = 5;

            EqualityScale<int> eqs2 = new EqualityScale<int>(leftTwo, rightTwo);
            Console.WriteLine(eqs2.AreEqual()); // true
        }
    }
}
