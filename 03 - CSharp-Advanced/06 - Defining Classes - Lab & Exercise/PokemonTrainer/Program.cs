using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Trainer> trainersList = new List<Trainer>();

            //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
            while (command.ToLower() != "tournament")
            {
                string[] newCmds = command.Split();

                string trainerName = newCmds[0];
                string pokemonName = newCmds[1];
                string pokemonElement = newCmds[2];
                int pokemonHealth = int.Parse(newCmds[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainersList.Any(t => t.Name == trainerName))
                {
                    Trainer trainer = trainersList.FirstOrDefault(t => t.Name == trainerName);

                    //if (trainersList.Any(t => t.PokemonCollection.Any(p => p.Name == pokemonName)))
                    //{
                    //    trainer.NumberOfBadges += 1;
                    //}
                    //else
                    //{
                    //    foreach (Pokemon p in trainer.PokemonCollection)
                    //    {
                    //        p.Health -= 10;

                    //        if (p.Health < 0)
                    //        {
                    //            trainer.PokemonCollection.Remove(p);
                    //        }
                    //    }
                    //}

                    if (!trainer.PokemonCollection.Contains(pokemon))
                    {
                        trainer.PokemonCollection.Add(pokemon);
                    }
                }
                else
                {
                    List<Pokemon> thisTrainersPokemons = new List<Pokemon>();
                    thisTrainersPokemons.Add(pokemon);

                    Trainer trainer = new Trainer(trainerName, 0, thisTrainersPokemons);
                    trainersList.Add(trainer);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command.ToLower() != "end")
            {
                foreach (Trainer trainer in trainersList)
                {
                    if (trainer.PokemonCollection.Any(p => p.Element == command))
                    {
                       trainer.NumberOfBadges += 1;
                    }
                    else
                    {
                        foreach (Pokemon p in trainer.PokemonCollection)
                        {
                            p.Health -= 10;

                            if (p.Health < 0)
                            {
                                trainer.PokemonCollection.Remove(p);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainerFin in trainersList)
            {
                Console.WriteLine($"{trainerFin.Name} {trainerFin.NumberOfBadges} {trainerFin.PokemonCollection.Count}");
            }
        }
    }
}
