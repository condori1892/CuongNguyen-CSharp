using System;
using System.Collections.Generic;

namespace collection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};
            // int[] numArray
            // numArray = new int[] {0,1,2,3,4,5,6,7,8,9};
            string[] names = new string[4] {"Tim",  "Martin", "Nikki", "Sara"};
            // foreach(string name in names)
            //     Console.WriteLine(name);
            bool[] values = new bool[10] {true, false, true, false, true, false, true, false, true, false};
            // foreach(bool value in values)
            //     Console.WriteLine(value);
            
            for(int i = 1; i <= 10; i++)
            {
               
                if(i < 10)
                    Console.Write("[ " + i + ", ");
                else
                    Console.Write("[ " + i + ",");
                for(int j = 2; j <= 10; j++)
                {
                    int k = i*j;
                    
                    if(k < 10)
                       Console.Write(k + ", ");
                    else
                        Console.Write(k + ",");
                }
                if(i != 10)
                    Console.Write(" ]");
                else
                    Console.Write("]");
                Console.WriteLine();
            }
            Console.WriteLine();
            int[,] array2D = new int[10,10] 
                {   {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                    {2, 4, 6, 8, 10,12,14,16,18,20},
                    {3, 6, 9, 12,15,18,21,24,27,30},
                    {4, 8, 12,16,20,24,28,32,36,40},
                    {5, 10,15,20,25,30,35,40,45,50},
                    {6, 12,18,24,30,36,42,48,54,60},
                    {7, 14,21,28,35,42,49,56,63,70},
                    {8, 16,24,32,40,48,56,64,72,80},
                    {9, 18,27,36,45,54,63,72,81,90},
                    {10,20,30,40,50,60,70,80,90,100}
                };
            Console.WriteLine(array2D[1,2]);
            Console.WriteLine();
            List<string> flavor = new List<string>();
            flavor.Add("Chocolate");
            flavor.Add("Vanila");
            flavor.Add("Mango");
            flavor.Add("Strawberry");
            flavor.Add("Coconut butter");
            flavor.Add("Coffee");
            for(int index = 0; index < flavor.Count; index++)
            {
                Console.WriteLine(flavor[index]);
            
            }
            Console.WriteLine(flavor.Count);
            foreach(string x in flavor)
                Console.WriteLine(x);
            Console.WriteLine(flavor[2]);
            flavor.Remove("Mango");
            Console.WriteLine(flavor.Count);
            Dictionary<string,string> user_flavor = new Dictionary<string,string>();
            user_flavor.Add("Tim","");
            user_flavor.Add("Martin","");
            user_flavor.Add("Mikki","");
            user_flavor.Add("Sara","");
            Console.WriteLine(user_flavor.Count);
            user_flavor.Clear();
            user_flavor.Add("Tim","Cofffe");
            user_flavor.Add("Martin","Chocolate");
            user_flavor.Add("Mikki","Vanila");
            user_flavor.Add("Sara","Strawberry");
            foreach(KeyValuePair<string,string> entry in user_flavor)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
            

        }
        

        
        
       
    }
}
