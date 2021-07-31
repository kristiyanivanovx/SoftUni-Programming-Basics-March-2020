using System;

namespace CustomListCustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomListExe();
            CustomStackExe();
        }

        private static void CustomStackExe()
        {
            CustomStack<int> cs = new CustomStack<int>();

            cs.Push(1);
            cs.Push(2);
            cs.Push(3);

            cs.Push(4);
            cs.Push(6);

            cs.XSelect(x => x * 99);
            cs.ForEach(Console.WriteLine);

            foreach (var item in cs)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(cs.Pop());
            Console.WriteLine(cs.Pop());
            Console.WriteLine(cs.Pop());

            Console.WriteLine(cs.Pop());
            //Console.WriteLine(cs.Pop());

            //Console.WriteLine(cs.Pop());

            Console.WriteLine(cs.Peek());

            foreach (var item in cs)
            {
                Console.WriteLine(item);
            }
        }

        private static void CustomListExe()
        {
            CustomList<int> cl = new CustomList<int>();

            cl.Add(1);
            cl.Add(2);

            cl.Insert(0, 3);
            cl.Insert(0, 4);
            cl.Insert(0, 5);
            cl.Insert(0, 6);
            cl.Insert(0, 7);

            cl.Swap(0, 1);

            Console.WriteLine("removed " + cl.RemoveAt(0));
            Console.WriteLine("removed " + cl.RemoveAt(0));

            Console.WriteLine("removed " + cl.RemoveAt(0));
            Console.WriteLine("removed " + cl.RemoveAt(0));

            Console.WriteLine("removed " + cl.RemoveAt(0));
            Console.WriteLine("removed " + cl.RemoveAt(0));

            foreach (var item in cl)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------");

            Console.WriteLine(cl.Contains(3));
            Console.WriteLine(cl.Contains(1));
        }
    }
}
