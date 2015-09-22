using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class SchoolTest
    {
        static void Main(string[] args)
        {
            Student studentOne = new Student("Ivan", "Dvoikadjiq", 1);
            Student studentTwo = new Student("Maria", "Otlichnik", 2);
            Student studentThree = new Student("Ana", 3);
            
            IList<Student> students = new List<Student>();
            students.Add(studentOne);
            students.Add(studentTwo);
            students.Add(studentThree);

            Discipline disciplineOne = new Discipline("Matematika", 12, students, "muka");
            Discipline disciplineTwo = new Discipline("Muzika", 12, students);

            IList<Discipline> disciplines = new List<Discipline>();
            disciplines.Add(disciplineOne);
            disciplines.Add(disciplineTwo);

            Teacher teacherOne = new Teacher("Petko", disciplines);

            IList<Teacher> teachers = new List<Teacher>();
            teachers.Add(teacherOne);

            Class classOne = new Class("Detska gradina", students, teachers);
            Console.WriteLine(classOne);
        }
    }
}
