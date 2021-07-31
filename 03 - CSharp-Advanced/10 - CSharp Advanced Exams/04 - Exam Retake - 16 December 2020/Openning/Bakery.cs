using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> data { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            this.data.Add(employee);

            // if there is room for him/her. 
            //if (this.Count < Capacity)
            //{
            //    this.data.Add(employee);
            //}
        }

        public bool Remove(string name)
        {
            Employee toRemove = this.data.FirstOrDefault(x => x.Name == name);

            //if (toRemove != null)
            //{
                this.data.Remove(toRemove);
                return true;
            //}

            //return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee mid = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return mid;
        }

        public Employee GetEmployee(string name)
        {
            Employee mid = data.FirstOrDefault(x => x.Name == name);
            return mid;
        }

        public string Report()
        {
            var result = $"Employees working at Bakery {this.Name}:";

            foreach (var employee in this.data)
            {
                result = result + Environment.NewLine + employee;
            }

            return result;
        }
    }
}
