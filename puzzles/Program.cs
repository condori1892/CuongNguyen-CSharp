using System;
using System.Collections;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        public static int[] RandomArray()
        {
            Random rand = new Random();
            int[] array = new int[10];
            for(int i = 0; i < 10; i++)
                array[i] = rand.Next(5,25);
            return array;
        }
        public static void MinMaxSum(int[] array)
        {
            int min = array[0], max = array[0], sum = 0;   
            for(int i=0; i<array.Length; i++)
            {
                Console.Write(array[i] + " ");
                if(array[i] > max)
                    max = array[i];
                if(array[i] < min)
                    min = array[i];
                sum += array[i];
            }
            Console.WriteLine("\nThe Min is: {0}. Max is : {1}. Sum is: {2}.", min, max, sum);
        }
        public static string TossCoin()
        {
            Random rand = new Random();
            int HeadOrTail = rand.Next(0,2);
            string result = "None";
            Console.WriteLine(HeadOrTail);

            Console.WriteLine("Tossing a Coin!");
            if(HeadOrTail == 0)
                result = "Head";
            else
                result = "Tails";
            Console.WriteLine(result);
            return result;
        }
        public static double TossMultipleCoins(int num)
        {
            Random rand = new Random();
            double value = 0.0, head = 0.0, tail = 0.0, result = 0.0;
            for(int i = 1; i <= num; i++)
            {
                value = rand.Next(0,2);
                if(value == 0.0)
                    head++;
                else
                    tail++;
            }
            result = head/tail;
            Console.WriteLine(result);
            
            return result;
        }
        public static string[] Names(string[] userName)
        {
            string[] names_array = new string[userName.Length];
            foreach(string name in userName)
                Console.WriteLine(name);

            Array.Sort(userName);
            Console.WriteLine("New Sort of names:");
            foreach(string name in userName)
                Console.WriteLine(name);

            List<string> new_array = new List<string>();
            foreach(string name in userName)
            {
                int count = 0;
                foreach(char c in name)
                    count++;
                if(count > 5)
                    new_array.Add(name);
            }
            Console.WriteLine("New List of Names:");
            foreach(string n in new_array)
                Console.WriteLine(n);
            string[] listToArray = new_array.ToArray();

            Console.WriteLine("New Array to Return: ");
            foreach(string n in listToArray)
                Console.WriteLine(n);


            return listToArray;
        }
        static void Main(string[] args)
        {
            int[] randAray = RandomArray();
            MinMaxSum(randAray);
            string coinFlip = TossCoin();
            double ratio = TossMultipleCoins(50);
            string[] name_array = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] users_name = Names(name_array);

        }
    }
}
