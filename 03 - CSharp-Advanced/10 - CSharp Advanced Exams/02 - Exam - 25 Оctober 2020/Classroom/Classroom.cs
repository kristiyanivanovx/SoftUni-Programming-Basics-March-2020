using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> students;

        public int Capacity { get; set; }

        public int Count { get => this.students.Count; }

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student studentToRemove = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (studentToRemove != null)
            {
                this.students.Remove(studentToRemove);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsWithThisSubject = students.FindAll(x => x.Subject == subject);

            if (studentsWithThisSubject.Count > 0)
            {
                var result = $"Subject: {subject}" + Environment.NewLine + "Students:";

                foreach (var student in studentsWithThisSubject)
                {
                    result = result + Environment.NewLine + $"{student.FirstName} {student.LastName}";
                }

                return result;
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            int studentsInRoomCount = students.Count;
            return studentsInRoomCount;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student neededStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return neededStudent;
        }
    }
}
