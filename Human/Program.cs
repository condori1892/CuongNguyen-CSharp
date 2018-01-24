using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            object p3 = "somthine";
            Person p1 = new Person("John");
            Console.WriteLine(" {0}  {1} {2} {3} {4}", p1.Name, p1.Strength, p1.Dexterity, p1.Strength, p1.Health);
            Person p2 = new Person("Minh");
            Console.WriteLine(" {0}  {1} {2} {3} {4}", p2.Name, p2.Strength, p2.Dexterity, p2.Strength, p2.Health);
            p2.Attack(p1);
            Console.WriteLine(" {0}  {1} {2} {3} {4}", p1.Name, p1.Strength, p1.Dexterity, p1.Strength, p1.Health);
        

        }
    }
}
