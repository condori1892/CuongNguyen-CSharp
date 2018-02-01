using System.Collections.Generic;

namespace randomPasscode.Models
{
    public class Initalize
    {
        // public string status {get;set;} = "start";
        // public int happiness {get;set;} = 50;
        // public int fullness {get;set;} = 20;
        // public int energy {get;set;} = 20;
        // public int meals {get;set;} = 3;
        public string status;
        public int happiness;
        public int fullness;
        public int meals;
        public int energy;
        public Initalize()
        {
            status = "Initalize";
            happiness = 20;
            fullness = 20;
            happiness = 50;
            meals = 3;
        }

    }
}