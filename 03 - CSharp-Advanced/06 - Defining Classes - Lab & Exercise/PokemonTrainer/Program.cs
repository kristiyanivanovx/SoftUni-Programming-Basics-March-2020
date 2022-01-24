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
            List<Trainer> trainers = new List<Trainer>();

            while (command.ToLower() != "tournament")
            {
                string[] information = command.Split();
                string trainerName = information[0];
                string pokemonName = information[1];
                string pokemonElement = information[2];
                int pokemonHealth = int.Parse(information[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(t => t.Name == trainerName))
                {
                    Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                    trainer.PokemonCollection.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>() { pokemon });
                    trainers.Add(trainer);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                for (int trainer = 0; trainer < trainers.Count; trainer++)
                {
                    Trainer currentTrainer = trainers[trainer];
                    if (currentTrainer.PokemonCollection.Any(p => p.Element == command))
                    {
                        currentTrainer.NumberOfBadges += 1;
                    }
                    else
                    {
                        for (int pokemon = 0; pokemon < currentTrainer.PokemonCollection.Count; pokemon++)
                        {
                            Pokemon currentPokemon = currentTrainer.PokemonCollection[pokemon];
                            currentPokemon.Health -= 10;

                            if (currentPokemon.Health <= 0)
                            {
                                currentTrainer.PokemonCollection.Remove(currentPokemon);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(x => x.NumberOfBadges).ToList();

            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.PokemonCollection.Count}");
            }
        }
    }
}
