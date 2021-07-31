using System;

namespace Animals
{
    public abstract class Animal
    {
        private const string ErrorMessage = "Invalid input!";

        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessage);
                }
                
                this.name = value;
            } 
        }

        public int Age 
        { 
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.age = value;
            } 
        }

        public string Gender
        { 
            get => this.gender;
            private set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException(ErrorMessage);
                }

                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            var result = $"{this.GetType().Name}" + Environment.NewLine
                       + $"{this.Name} {this.age} {this.Gender}" + Environment.NewLine
                       + $"{this.ProduceSound()}";

            return result;
        }
    }
}
