namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            
        }

        public override double DefaultFuelConsumption
        { 
            get => base.DefaultFuelConsumption = 10; 
            protected set => base.DefaultFuelConsumption = value; // ?
        }
    }
}
