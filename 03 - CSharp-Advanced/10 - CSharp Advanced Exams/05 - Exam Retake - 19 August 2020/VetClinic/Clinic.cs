using System;
using System.Collections.Generic;
using System.Linq;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public int Capacity { get; set; }

        public int Count { get => this.data.Count; }

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (this.Count < Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet result = data.FirstOrDefault(x => x.Name == name);

            if (result != null)
            {
                this.data.Remove(result);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        { 
            List<Pet> result = data.FindAll(x => x.Name == name && x.Owner == owner);

            if (result != null)
            {
                return result[0];
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            int maxAge = int.MinValue;

            for (int pet = 0; pet < this.data.Count; pet++)
            {
                if (data[pet].Age > maxAge)
                {
                    maxAge = data[pet].Age;
                }
            }

            Pet res = data.FirstOrDefault(x => x.Age == maxAge);
            return res;
        }

        public string GetStatistics()
        {
            string result = $"The clinic has the following patients:";

            foreach (Pet pet in this.data)
            {
                result = result + Environment.NewLine + $"Pet {pet.Name} with owner: {pet.Owner}";
            }

            return result;
        }
    }
}
