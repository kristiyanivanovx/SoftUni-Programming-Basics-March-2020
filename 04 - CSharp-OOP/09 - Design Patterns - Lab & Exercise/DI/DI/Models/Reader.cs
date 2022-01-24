using System;
using DI.Interfaces;

namespace DI.Models
{
    public class Reader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
