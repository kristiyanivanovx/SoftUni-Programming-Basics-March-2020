namespace NeedForSpeed.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        //private const int RaceMotorcycleDefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double DefaultFuelConsumption 
        { 
            get => base.DefaultFuelConsumption = 8; 
            protected set => base.DefaultFuelConsumption = value; 
        }

    }
}
