using System;

namespace basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number 1 to 250: ");
            for(int i = 1; i <= 250; i++)
                Console.WriteLine(i);
        
            Console.WriteLine("Odd Number 1 to 250 :");
            for(int i = 1; i <= 250; i++)
                if(i%2 != 0)
                    Console.WriteLine(i);
            
            int sum = 0;
            for(int i = 0; i <= 250; i++)
            {
                sum +=i;
                Console.WriteLine("New Number: {0} Sum: {1}", i, sum);
            }
            int[] X = {1,3,5,7,9,13};
            for(int i = 0; i < X.Length; i++)
                Console.WriteLine(X[i]);
            foreach(int i in X)
                Console.WriteLine(i);
            
            int[] numbs = {1,3,5,7,9,13,-1,4,-7,8,-66,100,0};
            int y = 3;
            int max = numbs[0];
            int min = numbs[0];
            int average = 0;
            int total = 0;
            for(int i = 1; i<numbs.Length; i++)
            {
                total += numbs[i];
                if(numbs[i] > max)
                    max = numbs[i];
                else if(numbs[i] < min)
                    min = numbs[i];
            }
            Console.WriteLine("Max number is :" + max);
            Console.WriteLine("Min number is :" + min);

            average = total/(numbs.Length);
            Console.WriteLine(numbs.Length);
            Console.WriteLine("Average of numbs array is : " + average);
            Console.WriteLine("Greater than Y is : " + Greater(numbs,y) + " times");
           
            int[] numbArray = new int[128];
            for(int i = 1; i <= 255; i++)
                if(i%2 != 0)
                {
                    Console.WriteLine(i);
                }
            int value = 1;
            for(int i = 0; i<numbArray.Length; i++)
            {
                numbArray[i] = value;
                value = value + 2;
            }
            foreach(int i in numbArray)
                Console.WriteLine(i);
            
            



            for(int i = 0; i <numbs.Length -1; i++)
            {
                numbs[i] = numbs[i+1];
                if(i == numbs.Length -1)
                    numbs[i +1] = numbs[numbs.Length -1];
            }
            foreach(int i in numbs)
                Console.WriteLine(i);

            

            int[] numbs2 = {1,3,5,7,9,13,-1,4,-7,8,-66,100,0};
            for(int i = 0; i<numbs2.Length; i++)
                if(numbs2[i] < 0)
                    numbs2[i] = 0;
            foreach(int i in numbs)
                Console.WriteLine(i);

            int[] numbs3 = {1,3,5,7,9,13,-1,4,-7,8,-66,100,0};
            for(int i = 0; i<numbs3.Length; i++)
                numbs3[i] = numbs3[i]*numbs3[i];
            
            foreach(int i in numbs)
                Console.WriteLine(i);
            int[] numbs4 = {1,3,5,7,9,13,-1,4,-7,8,-66,100,0};
            string[] newArray = InttoString(numbs4);
            foreach(string s in newArray)
                Console.WriteLine(s);
            
        

        }
        public static string[] InttoString(int[] array)
        {
            string[] stringArray = new string[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] < 0)
                    stringArray[i] = "Dojo";
                else
                    stringArray[i] = Convert.ToString(array[i]);

            }
            return stringArray;
        }
        public static int Greater(int[] array, int numb)
        {
            int count = 0;
            foreach(int i in array)
                if(i > numb)
                    count++;
            return count;
        }
    }
}
