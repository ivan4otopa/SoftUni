using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentClass.Classes;

namespace StudentClass
{
    class StudentClassTest
    {
        static void Main(string[] args)
        {
            Student student = new Student("Genadi", 13);
            student.Name = "Petkana";
            student.Age = 98;
        }
    }
}
