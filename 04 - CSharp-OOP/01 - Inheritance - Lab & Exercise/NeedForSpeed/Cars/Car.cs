namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
            
        }

        public override double DefaultFuelConsumption
        {
            get => base.DefaultFuelConsumption = 3;
            protected set => base.DefaultFuelConsumption = value; // ?
        }
    }
}
