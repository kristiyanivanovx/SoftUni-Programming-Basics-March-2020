using System.Collections.Generic;

namespace SOLID.Models.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
