using System;

namespace HuWiNiSa
{
    // Ninja should have a default dexterity of 175  
    // Ninja should have a steal method, which when invoked, attacks an object 
    // and increases the Ninjas health by 10  
    // Ninja should have a get_away method, which when invoked, decreases its health by 15
    public class Ninja : Human 
    {
        public Ninja(string n) : base(n)
        {
            dexterity = 175;
        }
        public void Steal(object target)
        {
            Human enemy = target as Human;
            if(enemy != null) {
                enemy.health -= 10;
                health +=10;
            }
        }
        public void GetAway()
        {
            health -= 15;
        }
            

    }
}