using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassStudent.Classes
{
    class Student
    {
        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks,
            int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return String.Format("Student:\nFirst Name: {0}; Last Name: {1}; Age: {2}; Faculty Number: {3}; Phone: {4}; Email: {5}; " +
                "Marks: {6}; Group Number: {7}", this.FirstName, this.LastName, this.Age, this.FacultyNumber, this.Phone, this.Email,
                string.Join(", ", this.Marks.Select(m => m.ToString()).ToArray()), this.GroupNumber);
        }
    }
}
