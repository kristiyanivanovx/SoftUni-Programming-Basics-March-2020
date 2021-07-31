namespace Animals
{
    class Tomcat : Animal
    {
        private const string DefaultGender = "Male";

        public Tomcat(string name, int age)
            : base(name, age, DefaultGender)
        {

        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
