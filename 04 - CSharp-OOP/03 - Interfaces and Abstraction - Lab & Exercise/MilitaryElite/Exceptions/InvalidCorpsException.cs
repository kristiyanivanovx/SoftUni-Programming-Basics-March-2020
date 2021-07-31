using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string InvalidCorpsMessage = "Invalid corps!";

        public InvalidCorpsException()
            : base(InvalidCorpsMessage)
        {

        }

        public InvalidCorpsException(string message)
            : base(message)
        {

        }
    }
}
