using System;

namespace HuWiNiSa
{
//     Wizard should have a default health of 50 and intelligence of 25  
//     Wizard should have a method called heal, which when invoked, heals the Wizard by 10 * intelligence  
//      Wizard should have a method called fireball, which when invoked, 
//     decreases the health of whichever object it attacked by some random integer between 20 and 50
    public class Wizard : Human 
    {
        public Wizard(string n) : base(n)
        {
            intelligence = 25;
            health = 50;
        }
        public void Heal()
        {
            intelligence *=10;
        }
        public void FireBall(object target)
        {
            Human enemy = target as Human;
            Random rand = new Random();
            int damage = rand.Next(20,50);
            if(enemy != null) {
                enemy.health -= damage;
            }

        }
            

    }
}