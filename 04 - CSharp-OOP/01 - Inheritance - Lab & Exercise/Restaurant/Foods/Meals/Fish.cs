using Restaurant.Foods.Types;

namespace Restaurant.Foods.Meals
{
    public class Fish : MainDish
    {
        private const int FishGrams = 22;

        public Fish(string name, decimal price)
            : base(name, price, FishGrams)
        {
            
        }
    }
}
