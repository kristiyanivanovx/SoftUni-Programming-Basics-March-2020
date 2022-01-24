using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double armor;

        public Character(string name, double health,
            double armor, double abilityPoints, Bag bag)
        {
            Name = name;

            Health = health;
            BaseHealth =  health; 
            Armor =  armor;
            BaseArmor = armor;

            AbilityPoints = abilityPoints;
            Bag = bag;
        }
        
        public bool IsAlive { get; set; } = true;
        public double AbilityPoints { get; set; }
        public Bag Bag { get; set; }

        public string Name
        {
            get { return name; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                
                name = value;
            }
        }

        public double BaseArmor { get; set; }

        public double BaseHealth
        {
            get { return baseHealth; }
            set
            {
                baseHealth = value;
            }
        }

        //?
        public double Health
        {
            get { return health; }
            set
            {
                if (value >= 0 && health <= BaseHealth)
                {
                    health = value;
                }
                else
                {
                    health = 0;
                }
            }
        }

        //?
        public double Armor 
        {
            get { return armor; }
            set
            {
                if (value >= 0)
                {
                    armor = value;
                }
            }
        }

        public void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        //?
        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double remaining = 0;
            if (hitPoints > armor)
            {
                remaining = armor -hitPoints;
            }

            this.armor -= hitPoints;
            //
            
            if (armor < 0)
            {
                //this.health += Math.Abs(armor);
                armor = 0;
            }

            if (hitPoints >= 0 && armor == 0)
            {
                this.health -= hitPoints;
				
				
                if (remaining > 0)
                {
                    //health += Math.Abs();
                }
            }
			
			if (this.Health != 0 && this.Health != 100)
			{
                    this.Health+=10;
			}

            if (this.Health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        //?
        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}