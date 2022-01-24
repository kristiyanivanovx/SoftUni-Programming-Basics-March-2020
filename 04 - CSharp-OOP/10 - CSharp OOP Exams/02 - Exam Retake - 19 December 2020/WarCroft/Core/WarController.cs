using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private ICollection<Character> party;
		private ICollection<Item> itemPool;

        public WarController()
		{
			this.party = new List<Character>();
			this.itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			var characterType = args[0];
			var characterName = args[1];

			Character character = null; 
            if (characterType == nameof(Priest))
            {
				character = new Priest(characterName);
            }
			else if (characterType == nameof(Warrior))
			{
				character = new Warrior(characterName);
			}
			else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			this.party.Add(character);
			return string.Format(string.Format(SuccessMessages.JoinParty, characterName));
		}

		public string AddItemToPool(string[] args)
		{
			var itemType = args[0];

			Item item = null;
			if (itemType == nameof(FirePotion))
			{
				item = new FirePotion();
			}
			else if (itemType == nameof(HealthPotion))
			{
				item = new HealthPotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
			}

			itemPool.Add(item);
			return string.Format(string.Format(SuccessMessages.AddItemToPool, itemType));
		}

		public string PickUpItem(string[] args)
		{
			var characterName = args[0];
			var character = this.party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!this.itemPool.Any())
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }


			var item = this.itemPool.Last();
			character.Bag.AddItem(item);
			this.itemPool.Remove(item);

			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			var characterName = args[0];
			var itemName = args[1];

			var character = this.party.FirstOrDefault(x => x.Name == characterName);
			
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			
			var item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			var characters = this.party
				.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health);

			var sb = new StringBuilder();

            foreach (var character in characters)
            {
				// ap / armor???

				var aliveOrDead = character.IsAlive ? "Alive" : "Dead";
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {aliveOrDead}");
			}

			return sb.ToString();
		}

		public string Attack(string[] args)
		{
			var attackerName = args[0];
			var receiverName = args[1];

			var characterAttacker = this.party.FirstOrDefault(x => x.Name == attackerName);
			var characterReceiver = this.party.FirstOrDefault(x => x.Name == receiverName);

			if (characterAttacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (characterReceiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}

            if (!(characterAttacker is IAttacker))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}

            if (characterAttacker == characterReceiver)
            {
				throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }
			
			characterReceiver.TakeDamage(characterAttacker.AbilityPoints);

			//?
			var output = $"{attackerName} attacks {receiverName} for {characterAttacker.AbilityPoints} hit points! {receiverName} has {characterReceiver.Health}/{characterReceiver.BaseHealth} HP and {characterReceiver.Armor}/{characterReceiver.BaseArmor} AP left!";
            if (!characterReceiver.IsAlive)
            {
				output += Environment.NewLine + $"{receiverName} is dead!";
			}

			return output;
		}

		public string Heal(string[] args)
		{
			var healerName = args[0];
			var healingReceiverName = args[1];

			var healer = this.party.FirstOrDefault(x => x.Name == healerName);
			var characterToHeal = this.party.FirstOrDefault(x => x.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (characterToHeal == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterToHeal));
			}

			if (healer is Warrior || !(healer is Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			characterToHeal.Health += healer.AbilityPoints;
			return string.Format($"{healer.Name} heals {characterToHeal.Name} for {healer.AbilityPoints}! {characterToHeal.Name} has {characterToHeal.Health} health now!");
		}
	}
}
