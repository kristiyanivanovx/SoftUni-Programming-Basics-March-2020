namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int defaultPower = 100;

        public Paladin(string name)
            : base(name, defaultPower)
        {

        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
