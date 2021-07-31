using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionException : Exception
    {
        public const string InvalidMissionCompletionMessage = "Mission already completed!";

        public InvalidMissionCompletionException()
            : base(InvalidMissionCompletionMessage)
        {

        }

        public InvalidMissionCompletionException(string message)
            : base(message)
        {

        }
    }
}
