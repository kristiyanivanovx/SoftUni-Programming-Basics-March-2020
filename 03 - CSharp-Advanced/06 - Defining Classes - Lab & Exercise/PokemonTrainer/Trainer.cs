using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> PokemonCollection { get; set; }

        public Trainer(string name, int numberOfBadges, List<Pokemon> pokemonCollection)
        {
            this.Name = name;
            this.NumberOfBadges = numberOfBadges;
            this.PokemonCollection = pokemonCollection;
        }
    }
}
