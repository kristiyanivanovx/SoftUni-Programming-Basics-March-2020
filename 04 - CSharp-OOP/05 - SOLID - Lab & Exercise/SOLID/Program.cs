using System;
using System.Linq;
using System.Collections.Generic;

using SOLID.Factories;
using SOLID.Models;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;
using SOLID.IOManagement.Interfaces;
using SOLID.Files;
using SOLID.IOManagement;
using SOLID.Models.PathManagement;
using SOLID.Core.Interfaces;
using SOLID.Core;

namespace SOLID
{
    public class Program
    {   
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);
            ILogger logger = SetUpLogger(n, writer, reader, file, layoutFactory, appenderFactory);
            IEngine engine = new Engine(logger, reader, writer);
            
            engine.Run();

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }

        private static ILogger SetUpLogger(int appendersCount, IWriter writer, IReader reader, IFile file,
            LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();
            
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                bool hasError = false;
                Level level = ParseLevel(appendersInfo, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreteAppender(appenderType, layout, level, file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            ILogger logger = new Logger(appenders);
            return logger;
        }

        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.Info;

            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine("Invalid threshold level provided.");
                    hasError = true;
                }

                appenderLevel = (Level) enumParsed;
            }

            return appenderLevel;
        }
    }
}
