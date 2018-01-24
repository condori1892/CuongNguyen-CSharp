using System;

namespace HuWiNiSa
{
    // Samurai should have a default health of 200  Samurai should have a method called death_blow, 
    // which when invoked should attack an object and decreases its health to 0 if it has less than 50 health  
    // Samurai should have a method called meditate, which when invoked, heals the Samurai back to full health  
    // (optional) Samurai should have a class method called how_many, which when invoked, 
    // displays how many Samurai's there are. Hint you may have to use the static keyword
    public class Samurai : Human 
    {
        static int samurais = 0;
        public Samurai(string n) : base(n)
        {
            samurais++;
            health = 200;
        }
        public void how_many()
        {
            Console.WriteLine($"Number of ninja(s): {samurais}");
        }
        public void death_blow(object target)
        {
            Human enemy = target as Human;
            if(enemy != null && enemy.health < 50) {
                enemy.health = 0;
                health +=10;
            }
        }
        public void meditate()
        {
            health = 200;
        }
            

    }
    
}