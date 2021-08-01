using System;
using System.Collections.Generic;
using System.Linq;

namespace Students
{
    class Student
    {
        public Student(string fullName, double grade)
        {
            this.FullName = fullName;
            this.Grade = grade;
        }

        public string FullName { get; set; }
        public double Grade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int value = int.Parse(Console.ReadLine());

            for (int i = 0; i < value; i++)
            {
                string[] studentData = Console.ReadLine().Split(" ");
                Student student = new Student(studentData[0] + " " + studentData[1], double.Parse(studentData[2]));
                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();
            students.ForEach(x => Console.WriteLine($"{x.FullName}: {x.Grade:f2}"));
        }
    }
}
