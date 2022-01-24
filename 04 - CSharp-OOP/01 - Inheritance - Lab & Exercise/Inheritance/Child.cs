namespace Inheritance
{
    public class Child : Person
    {
        private const int ChildAllowedMaxAge = 15;

        public Child(string name, int age)
            : base (name, age)
        {
        
        }

        public override int Age 
        {
            get 
            {
                return base.Age;
            }
            protected set 
            { 
                if (base.Age <= ChildAllowedMaxAge)
	            {
                    base.Age = value;
                }
            }
        }
    }
}
