using System.Collections.Generic;
using System;

namespace Game1.Models
{
    public class Dojodachi
    {
        public string message;
        public string action;
        public int happiness = 20;
        public int fullness = 20;
        public int energy = 50;
        public int meals = 3;
        private Random Rand = new Random();
        // private static int LikeOrNot;
        public Dojodachi()
        {
            message = "New Game";
            action = @"images/newgame.gif";
        }
        public void Feed()
            
        {
            if(meals > 0)
            {
                action = @"images/feeding.gif";
                meals--;
                // == 1 is dont like (25% dont like)
                if(Rand.Next(1,5) != 1)
                {
                    int bonus = Rand.Next(5,11);
                    fullness += bonus;
                    message = $"You just fed Dojodachi and She loved it! Meal(s): -{1} Fullness: {bonus}";
                    
                
                }
                else
                    message = $"You just fed Dojodachi and She NOT loved it! Meal(s): -{1}";
                
            }
            else
            {
                message = "No Meal!! Need to Work to earn meal(s)";  
                action = @"images/sad.gif";
            }
        
        }
        public void Play()
        { 
            if(energy >= 5)
            {
                action = @"images/playing.gif";
                energy -= 5;
                // == 1 is dont like (25% dont like)
                if(Rand.Next(1,5) != 1)
                {
                    int bonus = Rand.Next(5,11);
                    happiness += bonus;
                    message = $"You just played Dojodachi and She love playing! Happiness: +{bonus}  Energy: -5";  

                }
                else
                    message = $"You just played Dojodachi and She got bored! Energy: -5";
            }
            else
            {
                message = "There is no Energy left!";
                action = @"images/sad.gif";
            }
        }

        public void Work()
        {   
            if(energy >= 5)
            {
                action = @"images/working.gif";
                energy -= 5;
                int bonus = Rand.Next(1,4);
                meals += bonus;
                message = $"You just made Dojodachi Working! Meal(s): +{bonus}  Energy: -5";
            }
            else
            {
                message = "There is no Energy left!"; 
                action = @"images/sad.gif";

            }
        }

        public void Sleep()
        {
            action = @"images/sleeping.gif";
            fullness -= 5;
            happiness -= 5;
            energy += 15;
            message = "Your Dojodachi just slept! Happiness: -5  Energy: +15  Happiness: -5"; 
            
        }
        public void CheckDojodachi()
        {
            if(energy > 100 && fullness > 100 && happiness > 100)
            {
                message = "Congratulation! You Won!!";
                action = @"images/winning.gif";
            }
            if( fullness <= 0 || happiness <= 0)
            {
                message = "Your Dojodachi just went to Second Vegas!!";
                action = @"images/losing.gif";
            }
        }
    
    }
    
}


//******************************************* */
// using System.Collections.Generic;

// namespace Games.Models
// {
//     public class Golding
//     {
//         public int Gold;
//         public List<string> Activities;
//         public Golding()
//         {
//             Gold = 0;
//             Activities = new List<string>();
//         }
//     }
// }