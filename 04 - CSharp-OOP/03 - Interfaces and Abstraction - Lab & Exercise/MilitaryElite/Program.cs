﻿using MilitaryElite.Core;
using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
