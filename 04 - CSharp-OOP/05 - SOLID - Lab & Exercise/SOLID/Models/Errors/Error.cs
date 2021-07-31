using System;
using SOLID.Models.Enumeration;
using SOLID.Models.Interfaces;

namespace SOLID
{
    public class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }

        public DateTime DateTime { get; set; }

        public string Message { get; set; }

        public Level Level { get; set; }
    }
}
