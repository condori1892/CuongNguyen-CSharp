using System;

namespace HuWiNiSa
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Minh = new Human("Minh");
            Ninja Kim = new Ninja("Kim");
            Wizard Cuong = new Wizard("Cuong");
            Samurai Don = new Samurai("Don");
            Samurai c = new Samurai("c");
            Cuong.FireBall(Minh);
            Console.WriteLine(Minh.health);
            Kim.Steal(Cuong);
            Console.WriteLine(Cuong.health);
            Kim.GetAway();
            Console.WriteLine(Kim.health);
            Don.death_blow(Cuong);
            Console.WriteLine(Cuong.health);
            Don.how_many();
            



        }
    }
}
