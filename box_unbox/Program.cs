using System;
using System.Collections.Generic;

namespace box_unbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> objectList = new List<object>();
            objectList.Add(7);
            objectList.Add(28);
            objectList.Add(-1);
            objectList.Add(true);
            objectList.Add("chair");
            foreach(object x in objectList)
            {
                Type t = x.GetType();
                Console.WriteLine("{0} is type of {1}", x, t);
            }
            int sum =0 ;
            foreach(object x in objectList)
            {
                if(x is int)
                {
                    int hold = Convert.ToInt32(x);
                    sum = sum + hold;
                }
            }

            Console.WriteLine("The Sum in List of int objects: {0}", sum);

        }
    }
}
