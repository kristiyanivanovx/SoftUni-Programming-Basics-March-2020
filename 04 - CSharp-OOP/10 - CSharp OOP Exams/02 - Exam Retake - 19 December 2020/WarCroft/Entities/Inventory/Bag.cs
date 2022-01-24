using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        public Bag()
        {
            this.items = new List<Item>();
        }

        public Bag(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load 
            => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items 
            => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if ((Load + item.Weight) > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        // ?
        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);
            return item;
        }
    }
}
