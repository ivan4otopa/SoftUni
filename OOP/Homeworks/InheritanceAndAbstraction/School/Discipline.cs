using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Discipline
    {
        private string name;
        private int numberOfLectures;
        private IList<Student> students = new List<Student>();
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of discipline cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of lectures must be greater than 0.");
                }
                this.numberOfLectures = value;
            }
        }
        public string Details { get; set; }
        public Discipline(string name, int numberOfLectures, IList<Student> students, string details)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.students = students;
            this.Details = details;
        }
        public Discipline(string name, int numberOfLectures, IList<Student> students)
            : this(name, numberOfLectures, students, null)
        {
        }
        public override string ToString()
        {
            if (this.Details != null)
            {
                return String.Format("Discipline Name: {0}; Details: {1}; Number Of Lectures: {2};  Students:\n{3}", this.name,
                    this.Details, this.numberOfLectures, string.Join("\n", this.students.Select(s => s.ToString()).ToArray()));
            }
            return String.Format("Discipline Name: {0}; Number Of Lectures: {1}; Students:\n{2}", this.name,
                    this.numberOfLectures, string.Join("\n", this.students.Select(s => s.ToString()).ToArray()));
        }
    }
}
