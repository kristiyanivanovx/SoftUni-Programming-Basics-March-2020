using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; }
        
        public string Color { get; set; }

        public Car(string model, Engine engine, string weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            return 
                $"{this.Model}:" + Environment.NewLine +
                $"  {this.Engine.Model}:" + Environment.NewLine +
                $"    Power: {this.Engine.Power}" + Environment.NewLine +
                $"    Displacement: {this.Engine.Displacement}" + Environment.NewLine +
                $"    Efficiency: {this.Engine.Efficiency}" + Environment.NewLine +
                $"  Weight: {this.Weight}" + Environment.NewLine +
                $"  Color: {this.Color}";
        }
    }
}
