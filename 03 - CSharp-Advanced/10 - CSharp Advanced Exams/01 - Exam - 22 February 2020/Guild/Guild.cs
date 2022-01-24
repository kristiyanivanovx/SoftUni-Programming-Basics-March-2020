using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.roster.Count; }

        public Guild(string name, int capacity)
        {
            this.roster = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void AddPlayer(Player player) 
        {
            // if there is room! <-
            if (this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = this.roster.FirstOrDefault(x => x.Name == name);

            if (toRemove != null)
            {
                this.roster.Remove(toRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player toPromote = this.roster.FirstOrDefault(x => x.Name == name);

            if (toPromote.Rank != "Member")
            {
                toPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player toDemote = this.roster.FirstOrDefault(x => x.Name == name);

            if (toDemote.Rank != "Trial")
            {
                toDemote.Rank = "Trial";
            }
        }

        // ?
        public Player[] KickPlayersByClass(string classString)
        {
            List<Player> toKick = this.roster.FindAll(x => x.Class == classString);

            // can be done better!
            foreach (var p in toKick)
            {
                this.roster.Remove(p);
            }

            return toKick.ToArray();
        }

        // ?
        public string Report()
        {
            string result = $"Players in the guild: {this.Name}";
            foreach (Player player in this.roster)
            {
                result = result + Environment.NewLine + player;
            }

            return result;
        }
    }
}
