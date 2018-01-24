using System;
using System.Collections;
using System.Collections.Generic;
using DbConnection;

namespace simpleCRUD
{
    class Program
    {
        public static void readCommand()
        {
            string command = "y";
            while(command == "y" || command == "c" || command == "r" || command == "u" || command == "d")
            {
                Console.WriteLine("y to Continue, c to Create, r to Read, u to Update, d to Delete, any key to Stop:");
                command = Console.ReadLine();
                if(command == "c")
                    Create();
                if(command == "r")
                    ReadAll();
                if(command == "u")
                    Update();
            }
        }
        public static void Update()
        {
            int id = -1;
            Console.WriteLine("Enter id number: ");
            while(id == -1)
            {
                try
                {
                    id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine(id);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Enter id number again: ");
                    id = -1;
                }
            }
            List<Dictionary<string,object>> updateQuery = DbConnector.Query($"SELECT * FROM user WHERE id = {id}");
            Console.WriteLine(updateQuery);
            if(updateQuery == null)
                Console.WriteLine($"There is No record # {id}");
            else
                foreach(var q in updateQuery)
                    Console.WriteLine($"{q["id"]} {q["first_name"]} {q["last_name"]} {q["favorite_number"]}");


        }
        public static void ReadAll()
        {
            List<Dictionary<string,object>> query = DbConnector.Query("SELECT * FROM user");
            // Console.WriteLine(query);
            foreach(var q in query)
                Console.WriteLine($"{q["id"]} {q["first_name"]} {q["last_name"]} {q["favorite_number"]}");

        }
        public static void Create()
        {
            Console.WriteLine("Enter your first name:");
            string f_name = Console.ReadLine();
            Console.WriteLine("Enter your last name:");
            string l_name = Console.ReadLine();
            Console.WriteLine("Enter your favorite number:");
            int f_number;
            try
            {
                f_number = Int32.Parse(Console.ReadLine());
                Console.WriteLine(f_number);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message + " We add 0 instead!!!hohooc");
                f_number = 0;
            }
            Console.WriteLine(f_number);
            string timeNow = "NOW()";
            string createQuery = $"INSERT INTO user (first_name, last_name, favorite_number, created_at, updated_at) VALUES ('{f_name}', '{l_name}', '{f_number}', {timeNow}, {timeNow})";
            DbConnector.Execute(createQuery);
            

        }
        static void Main(string[] args)
        {
            readCommand();
           
        }
    }
}
