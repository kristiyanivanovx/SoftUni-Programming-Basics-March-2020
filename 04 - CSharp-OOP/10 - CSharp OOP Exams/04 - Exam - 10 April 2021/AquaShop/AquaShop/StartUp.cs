using System;
using AquaShop.Core;
using AquaShop.Core.Contracts;

namespace AquaShop
{
    public class StartUp
    {
        public static void Main()
        {
            //start at 18 55
            IEngine engine = new Engine();
            engine.Run();

            Console.WriteLine(typeof(Engine).Name);
            Console.WriteLine(engine.GetType().Name);
        }
    }
}
