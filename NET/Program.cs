using System;

namespace NET
{
    class Program
    {
        static void Main(string[] args)
        {
           for(int val = 1; val <=255; val++)
           {
               Console.WriteLine(val);
           }
            for(int val = 1; val <=100; val++){
                if(val%3 == 0 || val%5 == 0)
                {
                    Console.WriteLine(val);
                }
            }
            for(int val = 1; val <=100; val++){
                if(val%3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                if(val%5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                if(val%3 == 0 || val%5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
            }
            Console.WriteLine(9/3 + " = " + 9/3.0);
            for(int val = 1; val <=100; val++){
                if(val/3 == val/3.0)
                {
                    Console.WriteLine("Fizz" + val);
                }
                if(val/5 == val/5.0)
                {
                    Console.WriteLine("Buzz" + val);
                }
                if(val/3 == val/3.0 || val/5 == val/5.0)
                {
                    Console.WriteLine("FizzBuzz" + val);
                }
            }


        }
    }
}
