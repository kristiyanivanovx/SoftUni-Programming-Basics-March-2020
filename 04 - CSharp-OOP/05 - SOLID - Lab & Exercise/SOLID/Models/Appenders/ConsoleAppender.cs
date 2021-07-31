using System;
using SOLID.IOManagement;
using SOLID.IOManagement.Interfaces;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;

namespace SOLID.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            : base(layout, level)
        {
            this.writer = new ConsoleWriter();
        }

        public string ProvideInformation(string info)
        {
            return info;
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatted = string.Format(format, dateTime.ToString("G"), level.ToString(), message);
            this.writer.WriteLine(formatted);
            this.messagesAppended += 1;
        }
    }
}
