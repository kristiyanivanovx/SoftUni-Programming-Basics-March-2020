using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Tire
    {
        public int year;

        public int pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }

        public double Pressure { get; set; }
    }
}
