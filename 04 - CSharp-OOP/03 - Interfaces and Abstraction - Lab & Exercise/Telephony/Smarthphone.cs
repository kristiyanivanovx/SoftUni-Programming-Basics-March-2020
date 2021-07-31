using System;
using PersonInfo.Interfaces;

namespace PersonInfo
{
    public class Smarthphone : IBrowseable, ICallable
    {
        public void BrowseTheWeb(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void CallOthers(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
