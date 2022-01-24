using System;
using Raiding.Models;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int value = int.Parse(Console.ReadLine());

            while (raidGroup.Count != value)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                bool typeIsUnknown = type != "Druid" && type != "Paladin" && type != "Rogue" && type != "Warrior";
                
                if (typeIsUnknown)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    BaseHero hero = CreateHero(name, type);
                    raidGroup.Add(hero);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            raidGroup.ForEach(x => Console.WriteLine(x.CastAbility()));

            int heroesTotalPower = raidGroup.Any() ? raidGroup.Sum(x => x.Power) : 0;
            if (heroesTotalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }

            return hero;
        }
    }
}
