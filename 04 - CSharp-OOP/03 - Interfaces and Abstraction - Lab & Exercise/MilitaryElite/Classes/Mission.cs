using System;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }
            
             this.State = State.Finished;
        }

        private State TryParseState(string state)
        {
            bool parsed = Enum.TryParse(state, out State stateParsed);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            return stateParsed;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
