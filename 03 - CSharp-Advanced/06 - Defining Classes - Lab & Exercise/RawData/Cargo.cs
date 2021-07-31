using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Cargo
    {
        private double cargoWeight;

        private string cargoType;

        public double CargoWeight;

        public string CargoType;

        public Cargo(double cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
    }
}
