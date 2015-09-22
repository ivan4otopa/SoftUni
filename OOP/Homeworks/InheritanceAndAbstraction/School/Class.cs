using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Class
    {
        private string uniqueTextIdentifier;
        private IList<Student> students = new List<Student>();
        private IList<Teacher> teachers = new List<Teacher>();
        public string UniqueTextIdentifier
        {
            get
            {
                return this.uniqueTextIdentifier;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Unique Text Identifier cannot be null or empty.");
                }
                this.uniqueTextIdentifier = value;
            }
        }
        public string Details { get; set; }
        public Class(string uniqueTextIdentifier, IList<Student> students, IList<Teacher> teachers, string details)
        {
            this.UniqueTextIdentifier = uniqueTextIdentifier;
            this.students = students;
            this.teachers = teachers;
            this.Details = details;
        }
        public Class(string uniqueTextIdentifier, IList<Student> students, IList<Teacher> teachers)
            : this(uniqueTextIdentifier, students, teachers, null)
        {
        }
        public override string ToString()
        {
            if (this.Details != null)
            {
                return String.Format("Unique Text Identifier: {0}; Details: {1}; Students:\n{2}\nTeachers:\n{3}",
                    this.uniqueTextIdentifier, this.Details, string.Join("\n", this.students.Select(s => s.ToString()).ToArray()),
                    string.Join("\n", this.teachers.Select(t => t.ToString()).ToArray()));
            }
            return String.Format("Unique Text Identifier: {0}; Students:\n{1}\nTeachers:\n{2}",
                    this.uniqueTextIdentifier, string.Join("\n", this.students.Select(s => s.ToString()).ToArray()),
                    string.Join("\n", this.teachers.Select(t => t.ToString()).ToArray()));
        }
    }
}
