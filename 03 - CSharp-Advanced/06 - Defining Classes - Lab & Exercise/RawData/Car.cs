using RawData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public List<Tire> Tires { get; set; }

        public Cargo Cargo { get; set; }

        public Car(string model, Engine engine, List<Tire> tires, Cargo cargo)
        {
            this.Model = model;
            this.Engine = engine;
            this.Tires = tires;
            this.Cargo = cargo;
        }
    }
}
