namespace NeedForSpeed.Motorcycles
{
    public class Motorcycle : Vehicle
    {
        public override double DefaultFuelConsumption 
        { 
            get => base.DefaultFuelConsumption; 
            protected set => base.DefaultFuelConsumption = value;
        }
        
        public override double FuelConsumption 
        { 
            get => base.FuelConsumption; 
            set => base.FuelConsumption = value; 
        }

        public Motorcycle(int horsePower, double fuel)
            : base (horsePower, fuel)
        {
            
        }
    }
}
