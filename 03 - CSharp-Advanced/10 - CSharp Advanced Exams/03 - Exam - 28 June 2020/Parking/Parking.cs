using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public string Type { get; set; }

        public int Capacity { get; set; }

        private List<Car> data;

        public int Count { get => this.data.Count; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car toBeRemoved = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (toBeRemoved != null)
            {
                this.data.Remove(toBeRemoved);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            Car oldestCar = this.data.OrderByDescending(x => x.Year).FirstOrDefault();
            return oldestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var neededCar = this.data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return neededCar;
        }

        public string GetStatistics()
        {
            var result = $"The cars are parked in {this.Type}:";

            foreach (var car in this.data)
            {
                result = result + Environment.NewLine + car;
            }

            return result;
        }
    }
}
