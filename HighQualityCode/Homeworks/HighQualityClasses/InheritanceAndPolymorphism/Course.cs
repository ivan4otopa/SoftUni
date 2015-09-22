using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InheritanceAndPolymorphism
{
    abstract class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

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
                    throw new ArgumentNullException("Course Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course Teacher Name cannot be null or empty.");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Course Students must be more than 0.");
                }

                this.students = value;
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ Name = ");
            result.Append(this.Name);
            result.Append("; Teacher = ");
            result.Append(this.TeacherName);
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");

            return result.ToString();
        }
    }
}
