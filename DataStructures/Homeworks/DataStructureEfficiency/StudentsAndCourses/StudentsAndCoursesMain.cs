namespace StudentsAndCourses
{
    using Properties;
    using System;
    using System.Collections.Generic;
    using System.IO;

    class StudentsAndCoursesMain
    {
        static void Main()
        {
            var coursesStudents = new SortedDictionary<string, SortedSet<Student>>();

            using (var reader = new StringReader(Resources.students))
            {
                string line = reader.ReadLine();
                string firstName = string.Empty;
                string lastName = string.Empty;
                string course = string.Empty;

                while (line != null)
                {
                    string[] tokens = line.Split('|');

                    firstName = tokens[0].Trim();
                    lastName = tokens[1].Trim();
                    course = tokens[2].Trim();

                    if (!coursesStudents.ContainsKey(course))
                    {
                        coursesStudents[course] = new SortedSet<Student>();
                    }

                    coursesStudents[course].Add(new Student(firstName, lastName));
                    line = reader.ReadLine();
                }
            }

            foreach (var courseStudents in coursesStudents)
            {
                Console.WriteLine(
                    "{0}: {1}",
                    courseStudents.Key,
                    string.Join(", ", courseStudents.Value));                
            }
        }
    }
}
