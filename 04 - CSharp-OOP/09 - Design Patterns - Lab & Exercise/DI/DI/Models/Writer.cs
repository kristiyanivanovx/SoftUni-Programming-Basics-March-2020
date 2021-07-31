using System;
using DI.Interfaces;

namespace DI.Models
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
