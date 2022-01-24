using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Engine
    {
        public int horsePower;

        public int cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }

        public double CubicCapacity { get; set; }
    }
}
