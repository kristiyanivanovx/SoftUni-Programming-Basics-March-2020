namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int defaultPower = 80;

        public Rogue(string name)
            : base(name, defaultPower)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
