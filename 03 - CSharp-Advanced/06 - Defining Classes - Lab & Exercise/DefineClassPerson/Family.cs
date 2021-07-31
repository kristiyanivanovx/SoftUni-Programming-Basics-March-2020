using System.Linq;
using System.Collections.Generic;

namespace DefineClassPerson
{
    public class Family
    {
        public List<Person> People { get; set; }

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.People.OrderByDescending(p => p.Age).FirstOrDefault();
            return oldestPerson;
        }
    }
}
