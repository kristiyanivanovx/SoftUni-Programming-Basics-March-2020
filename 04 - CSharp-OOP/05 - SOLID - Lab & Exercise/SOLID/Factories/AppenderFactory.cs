using SOLID.Models.Appenders;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }

        public IAppender CreteAppender(string appenderType, ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender" && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException("Invalid appender type provided.");
            }

            return appender;
        }
    }
}
