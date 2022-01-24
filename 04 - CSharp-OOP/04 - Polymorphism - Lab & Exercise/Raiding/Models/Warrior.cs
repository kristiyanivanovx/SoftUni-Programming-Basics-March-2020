namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int defaultPower = 100;

        public Warrior(string name)
            : base(name, defaultPower)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
