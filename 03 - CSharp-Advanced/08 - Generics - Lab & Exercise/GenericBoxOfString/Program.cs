using System;

namespace GenericBoxOfStringAndInt
{
    public class Program
    {
        static void Main(string[] args)
        {
            //StringBox();
            IntegerBox();
        }

        private static void StringBox()
        {
            int counter = int.Parse(Console.ReadLine());
            while (counter != 0)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                Console.WriteLine(box.ToString());
                counter--;
            }
        }

        private static void IntegerBox()
        {
            int counter = int.Parse(Console.ReadLine());
            while (counter != 0)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                Console.WriteLine(box.ToString());
                counter--;
            }
        }
    }
}
