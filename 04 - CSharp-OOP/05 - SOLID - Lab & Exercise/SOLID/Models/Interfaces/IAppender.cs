using System;
using SOLID.Models.Enumeration;

namespace SOLID.Models.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }
        
        void Append(IError error);
    }
}
