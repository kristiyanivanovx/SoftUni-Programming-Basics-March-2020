
namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium
    {
        public FreshwaterAquarium(string name)
            : base (name, 50)
        {
            this.Name = name;
        }
    }
}
