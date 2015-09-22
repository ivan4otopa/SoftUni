using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassStudent.Classes;

namespace ClassStudent
{
    class ClassStudentTest
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Vikito", "Haralambieva", 15, 341214, "+359 278758493", "Viki@abv.bg", new List<int> { 6, 6, 5, 6, 5 }, 1),
                new Student("Genadi", "Karaivanov", 16, 294814, "0878298459", "Gencho@gmail.bg", new List<int> { 6, 4, 5, 5 }, 2),
                new Student("Kiro", "Petrashkov", 21, 194738, "0888204735", "Kiro@abv.bg", new List<int> { 5, 2, 4, 3, 4 }, 2),
                new Student("Ana-Maria", "Veronikova", 13, 294383, "0278473805", "Ana-M@abv.bg", new List<int> { 5, 3, 2, 4 }, 3),
                new Student("Dimitrichka", "Zarkieva", 15, 523821, "+359288025734", "Dimitra@abv.bg", new List<int> { 6, 6, 6, 6, 6 }, 3),
                new Student("Petio", "Zazov", 19, 562848, "0878746382", "Petio@abv.bg", new List<int> { 3, 3, 2, 2 }, 1),
            };

            //PrintStudentsByGroup(students);
            //PrintStudentsByFirstNameAndLastName(students);
            //PrintStudentsByAge(students);
            //PrintSortedStudentsWithoutLINQQuerySyntax(students);
            //PrintSortedStudentsUsingLINQQuerySyntax(students);
            //PrintFilteredStudentsByEmailDomain(students);
            //PrintFilteredStudentsByPhone(students);
            //PrintExcellentStudents(students);
            //PrintWeakStudents(students);
            PrintStudentsEnrolledIn2014(students);
        }

        public static void PrintStudentsByGroup(List<Student> students)
        {
            var studentsByGroup =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            foreach (var student in studentsByGroup)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintStudentsByFirstNameAndLastName(List<Student> students)
        {
            var studentsByFirstNameAndLastName =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            foreach (var student in studentsByFirstNameAndLastName)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintStudentsByAge(List<Student> students)
        {
            var studentsByAge =
                from student in students
                where student.Age > 18 && student.Age < 24
                select new { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age };

            foreach (var student in studentsByAge)
            {
                Console.WriteLine(student.FirstName + "; " + student.LastName + "; " + student.Age);
            }
        }

        public static void PrintSortedStudentsWithoutLINQQuerySyntax(List<Student> students)
        {
            var sortedStudents = students.OrderBy(s => s.FirstName).ThenByDescending(s => s.LastName);

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintSortedStudentsUsingLINQQuerySyntax(List<Student> students)
        {
            var sortedStudents =
                from student in students
                orderby student.FirstName, student.LastName descending
                select student;

            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintFilteredStudentsByEmailDomain(List<Student> students)
        {
            var filteredStudentsByEmailDomain =
                from student in students
                where student.Email.Contains("@abv.bg")
                select student;

            foreach (var student in filteredStudentsByEmailDomain)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintFilteredStudentsByPhone(List<Student> students)
        {
            var filteredStudentsByPhone =
                from student in students
                where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
                select student;

            foreach (var student in filteredStudentsByPhone)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintExcellentStudents(List<Student> students)
        {
            var excellentStudents =
                from student in students
                where student.Marks.Contains(6)
                select new { Fullname = student.FirstName + " " + student.LastName, Marks = 
                    string.Join(", ", student.Marks) };

            foreach (var student in excellentStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintWeakStudents(List<Student> students)
        {
            var weakStudents = students.Where(s => s.Marks.Where(m => m == 2).Count() == 2);

            foreach (var student in weakStudents)
            {
                Console.WriteLine(student);
            }
        }

        public static void PrintStudentsEnrolledIn2014(List<Student> students)
        {
            var studentsEnrolledIn2014 =
                from student in students
                where student.FacultyNumber.ToString().EndsWith("14")
                select new { Marks = string.Join(", ", student.Marks) };

            foreach (var student in studentsEnrolledIn2014)
            {
                Console.WriteLine(student);
            }
        }
    }
}
