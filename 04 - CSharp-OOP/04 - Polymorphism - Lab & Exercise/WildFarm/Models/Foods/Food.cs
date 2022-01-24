using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int qty)
        {
            this.Quantity = qty;
        }

        public int Quantity { get; set; }
    }
}
