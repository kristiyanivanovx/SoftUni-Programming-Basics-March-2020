using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroesOfCodeAndLogic
{
	class Hero
	{
		public Hero(string name, int healthPoints, int manaPoints)
		{
			this.Name = name;
			this.HealthPoints = healthPoints;
			this.ManaPoints = manaPoints;
		}

		public string Name { get; set; }

		public int HealthPoints { get; set; }

		public int ManaPoints { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Hero> heroes = new List<Hero>();
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] data = Console.ReadLine().Split(" ");
				string name = data[0];
				int health = int.Parse(data[1]);
				int mana = int.Parse(data[2]);

				var hero = new Hero(name, health, mana);
				heroes.Add(hero);
			}

			string command = Console.ReadLine();
			while (!command.Contains("End"))
			{
				var data = command.Split(" - ");
				var action = data[0];
				var name = data[1];

				if (action == "CastSpell")
				{
					var manaPoints = int.Parse(data[2]);
					var hero = heroes.FirstOrDefault(x => x.Name == name);
					var spellName = data[3];

					if (hero.ManaPoints >= manaPoints)
					{
						hero.ManaPoints -= manaPoints;
						Console.WriteLine($"{hero.Name} has successfully cast {spellName} and now has {hero.ManaPoints} MP!");
					}
					else
					{
						Console.WriteLine($"{hero.Name} does not have enough MP to cast {spellName}!");
					}
				}
				else if (action == "TakeDamage")
				{
					var damage = int.Parse(data[2]);
					var attacker = data[3];
					var hero = heroes.FirstOrDefault(x => x.Name == name);
					hero.HealthPoints -= damage;

					if (hero.HealthPoints > 0)
					{
						Console.WriteLine($"{hero.Name} was hit for {damage} HP by {attacker} and now has {hero.HealthPoints} HP left!");
					}
					else
					{
						heroes.Remove(hero);
						Console.WriteLine($"{hero.Name} has been killed by {attacker}!");
					}
				}
				else if (action == "Recharge")
				{
					var manaPoints = int.Parse(data[2]);
					var hero = heroes.FirstOrDefault(x => x.Name == name);
					var rechargedFor = 0;

					if (hero.ManaPoints + manaPoints >= 200)
					{
						rechargedFor = manaPoints - (hero.ManaPoints + manaPoints - 200);
						hero.ManaPoints = 200;
					}
					else
					{
						rechargedFor = manaPoints;
						hero.ManaPoints += manaPoints;
					}

					Console.WriteLine($"{hero.Name} recharged for {rechargedFor} MP!");
				}
				else if (action == "Heal")
				{
					var healthPoints = int.Parse(data[2]);
					var hero = heroes.FirstOrDefault(x => x.Name == name);
					var healedFor = 0;
					
					if (hero.HealthPoints + healthPoints >= 100)
					{
						healedFor = healthPoints - (hero.HealthPoints + healthPoints - 100);
						hero.HealthPoints = 100;
					} 
					else
					{
						healedFor = healthPoints;
						hero.HealthPoints += healthPoints;
					}

					Console.WriteLine($"{hero.Name} healed for {healedFor} HP!");
				}

				command = Console.ReadLine();
			}

			heroes = heroes
				.OrderByDescending(x => x.HealthPoints)
				.ThenBy(x => x.Name)
				.ToList();

			heroes.ForEach(x =>
			{
				Console.WriteLine(x.Name);
				Console.WriteLine($"  HP: {x.HealthPoints}");
				Console.WriteLine($"  MP: {x.ManaPoints}");
			});
		}
	}
}
