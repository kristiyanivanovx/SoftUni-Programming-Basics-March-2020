using System;

namespace GenericArrayCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringsArr = ArrayCreator.Create(5, "asen");
            int[] integersArr = ArrayCreator.Create(5, 33);

            Console.WriteLine(string.Join(", ", stringsArr));
            Console.WriteLine(string.Join(", ", integersArr));
        }
    }
}
