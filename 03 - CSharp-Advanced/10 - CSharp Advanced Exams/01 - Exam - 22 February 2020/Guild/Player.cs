using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get; set; }

        public string Class { get; set; }

        public string Rank { get; set; } // trial by default 

        public string Description { get; set; } // n/a by default 

        public Player(string name, string classString)
        {
            this.Name = name;
            this.Class = classString;
            this.Rank = "Trial"; //?
            this.Description = "n/a"; //?
        }

        public override string ToString()
        {
            var result = $"Player {Name}: {Class}" + Environment.NewLine +
                         $"Rank: {Rank}" + Environment.NewLine +
                         $"Description: {Description}";

            return result;
        }

    }
}
