using System;
using System.Linq;
using System.Collections.Generic;

namespace Task04_Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { set; get; }
        
        public string LastName { set; get; }

        public double Grade { set; get; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfStudents = int.Parse(Console.ReadLine());

            List<Student> allStudents = new List<Student>();

            for (int i = 1; i <= numbersOfStudents; i++)
            {
                string[] nextStudentData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                Student nextStudent = new Student(nextStudentData[0], nextStudentData[1], double.Parse(nextStudentData[2]));

                allStudents.Add(nextStudent);
            }

            allStudents = allStudents.OrderByDescending(x => x.Grade).ToList();


            
            Console.WriteLine(string.Join((char)10, allStudents));
        }
    }
}
