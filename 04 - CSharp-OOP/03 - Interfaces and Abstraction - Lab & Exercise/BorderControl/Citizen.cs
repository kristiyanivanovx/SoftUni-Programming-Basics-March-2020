namespace BorderControl
{
    class Citizen : IBuyer
    {
        private int food;

        public Citizen(string name)
        {
            this.Name = name;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public int Food
        {
            get => this.food;
            private set
            {
                this.food = value;
            }
        }
        
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
