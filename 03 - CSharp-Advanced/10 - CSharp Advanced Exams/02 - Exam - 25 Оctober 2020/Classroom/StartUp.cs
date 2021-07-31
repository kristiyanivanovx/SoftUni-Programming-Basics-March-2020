namespace ClassroomProject
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            // Initialize the repository
            Classroom classroom = new Classroom(10);
            // Initialize entities

            Student student = new Student("Peter", "Parker", "Geometry");
            Student studentTwo = new Student("Sarah", "Smith", "Algebra");
            Student studentThree = new Student("Sam", "Winchester", "Algebra");
            Student studentFour = new Student("Dean", "Winchester", "Music");

            Student studentFive = new Student("Peter2", "Parker", "Geometry");
            Student studentSix = new Student("Sarah2", "Smith", "Algebra");
            Student studentSeven = new Student("Sam2", "Winchester", "Algebra");
            Student studentEight = new Student("Dean2", "Winchester", "Music");

            Student studentNine = new Student("Peter3", "Parker", "Geometry");
            Student studentTen = new Student("Sarah3", "Smith", "Algebra");
            Student studentEleven = new Student("Sam3", "Winchester", "Algebra");

            // Print Student
            //Console.WriteLine(student); // Student: First Name = Peter, Last Name = Parker, Subject = Geometry
                                        // Register Student
            string register1 = classroom.RegisterStudent(student);
            string register2 = classroom.RegisterStudent(studentTwo);
            string register3 = classroom.RegisterStudent(studentThree);
            string register4 = classroom.RegisterStudent(studentFour);
            string register5 = classroom.RegisterStudent(studentFive);
            string register6 = classroom.RegisterStudent(studentSix);
            string register7 = classroom.RegisterStudent(studentSeven);
            string register8 = classroom.RegisterStudent(studentEight);
            string register9 = classroom.RegisterStudent(studentNine);
            string register10 = classroom.RegisterStudent(studentTen);
            string register11 = classroom.RegisterStudent(studentEleven);

            string register12 = classroom.RegisterStudent(student);

            Console.WriteLine(register1);
            Console.WriteLine(register2);
            Console.WriteLine(register3);
            Console.WriteLine(register4);
            Console.WriteLine(register5);
            Console.WriteLine(register6);
            Console.WriteLine(register7);
            Console.WriteLine(register8);
            Console.WriteLine(register9);
            Console.WriteLine(register10);
            Console.WriteLine(register11);
            Console.WriteLine(register12);

            //Console.WriteLine(register1); // Added student Peter Parker
            string registerTwo = classroom.RegisterStudent(studentTwo);
            string registerThree = classroom.RegisterStudent(studentThree);
            string registerFour = classroom.RegisterStudent(studentFour);
            // Dismiss Student
            string dismissed = classroom.DismissStudent("Peter", "Parker");
            Console.WriteLine(dismissed); // Dismissed student Peter Parker
            string dismissedTwo = classroom.DismissStudent("Ellie", "Goulding");
            Console.WriteLine(dismissedTwo); // Student not found
                                             // Subject info
            string subjectInfo = classroom.GetSubjectInfo("Algebra");

            var info = classroom.GetStudentsCount();
            Console.WriteLine(subjectInfo);
            // Subject: Algebra
            // Students:
            // Sarah Smith
            // Sam Winchester
            string anotherInfo = classroom.GetSubjectInfo("Art");
            Console.WriteLine(anotherInfo); // No students enrolled for the subject
                                            // Get Student
            Console.WriteLine(classroom.GetStudent("Dean", "Winchester"));
            // Student: First Name = Dean, Last Name = Winchester, Subject = Music
        }
    }
}