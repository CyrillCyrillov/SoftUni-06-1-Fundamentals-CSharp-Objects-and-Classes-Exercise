using System;
using System.Linq;
using System.Collections.Generic;

namespace Task07_Order_by_Age
{
    class Person
    {
       

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }



        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if(data[0].ToUpper() == "END")
                {
                    break;
                }

                new Person = 


            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
