using SOLID.Core.Interfaces;
using SOLID.IOManagement.Interfaces;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;
using System;
using System.Globalization;
using System.Linq;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split('|').ToArray();

                string levelString = errorArgs[0];
                string dateTimeString = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelString, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine("Invalid level type provided.");
                }

                Level level = (Level)levelObj;
                bool isDateTimeValid = DateTime.TryParseExact(dateTimeString, "G", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine("Invalid DateTime Format.");
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }
            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
