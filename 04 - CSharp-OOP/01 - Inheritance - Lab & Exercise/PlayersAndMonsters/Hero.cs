using System;

namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username 
        {
            get => this.username;

            private set
            {
                if (value != string.Empty)
                {
                    this.username = value;
                }
                else
                {
                    throw new ArgumentException("Invalid username.");
                }
            } 
        }

        public int Level
        { 
            get => this.level;

            private set 
            {
                if (value >= 0)
                {
                    this.level = value;
                }
                else
                {
                    throw new ArgumentException("Invalid level.");
                }
            } 
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    } 
}
