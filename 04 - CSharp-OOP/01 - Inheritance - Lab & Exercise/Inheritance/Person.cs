namespace Inheritance
{
    public class Person
    {
        private const int PersonMinAllowedAge = 0;

        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual int Age 
        {
            get 
            {
                return this.age;
            }
            protected set 
            {
                if (value >= PersonMinAllowedAge)
                {
                    this.age = value;
                }
            }
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set 
            { 
                this.name = value; 
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
