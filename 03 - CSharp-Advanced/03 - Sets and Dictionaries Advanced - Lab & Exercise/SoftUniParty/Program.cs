using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            string hashCode = Console.ReadLine();
            HashSet<string> people = new HashSet<string>();

            while (!hashCode.ToLower().Contains("end"))
            {
                if (hashCode.ToLower().Contains("party"))
                {
                    hashCode = Console.ReadLine();

                    while (people.Contains(hashCode))
                    {
                        if (hashCode.ToLower().Contains("end"))
                        {
                            return;
                        }

                        people.Remove(hashCode);
                        hashCode = Console.ReadLine();
                    }
                }
                else
                {
                    people.Add(hashCode);
                    hashCode = Console.ReadLine();
                }

            }

            Console.WriteLine(people.Count);
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

//m8rfQBvl
//fc1oZCE0
//UgffRkOn
//7ugX7bm0
//9CQBGUeJ
//2FQZT3uC
//dziNz78I
//mdSGyQCJ
//LjcVpmDL
//fPXNHpm1
//HTTbwRmM
//B5yTkMQi
//8N0FThqG
//xys2FYzn
//MDzcM9ZK
//PARTY
//2FQZT3uC
//dziNz78I
//mdSGyQCJ
//LjcVpmDL
//fPXNHpm1
//HTTbwRmM
//B5yTkMQi
//8N0FThqG
//m8rfQBvl
//fc1oZCE0
//UgffRkOn
//7ugX7bm0
//9CQBGUeJ
//END

//2
//xys2FYzn
//MDzcM9ZK
    }
}
