using System;
using SOLID.Models.Enumeration;

namespace SOLID.Models.Interfaces
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
