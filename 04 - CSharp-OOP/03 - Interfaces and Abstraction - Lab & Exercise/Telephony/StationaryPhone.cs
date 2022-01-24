using System;
using PersonInfo.Interfaces;

namespace PersonInfo
{
    public class StationaryPhone : ICallable
    {
        public void CallOthers(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
