using SOLID.IOManagement.Interfaces;
using System;

namespace SOLID.IOManagement
{
    class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
