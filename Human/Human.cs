using System;

namespace Human
{
    class Person
    {
        //name, strength, intelligence, dexterity, and health.
        public string Name;
        public int Strength = 3;
        public int Intelligence = 3;
        public int Dexterity = 3;
        public int Health = 100;

        //Give a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
        
        //When an object is constructed from this class it should have the ability to pass a name
        public Person(string name)
        {
            Name = name; 
        }
        //Let's create an additional constructor that accepts 5 parameters, so we can set custom values for every field.

        public Person(string name, int strength, int intelligence, int dexterity, int health)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;
            
        }
        //Now add a new method called attack, which when invoked, 
        //should attack another Human object that is passed as a parameter. The damage done should be 5 * strength 
        //(5 points of damage to the attacked, for each 1 point of strength of the attacker).

        public void Attack(Person p)
        {
            if(p is Person)
                p.Health = p.Health - 5*p.Strength;
            else
                Console.WriteLine("Can Not Attack!!");
        }








    }


}