namespace StudentSystem.ConsoleClient
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentContext();

            //Seed(context);

            //var homeworks = context.Homeworks
            //    .Select(h => new
            //    {
            //        h.Content,
            //        h.ContentType,
            //        StudentName = h.Student.Name
            //    });

            //foreach (var homework in homeworks)
            //{
            //    Console.WriteLine("{0}, {1} - {2}", homework.Content, homework.ContentType.ToString(), homework.StudentName);
            //}

            //var courses = context.Courses
            //    .OrderBy(c => c.StartDate)
            //    .ThenByDescending(c => c.EndDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Description,
            //        Resources = c.Resources
            //    });

            //foreach (var course in courses)
            //{
            //    Console.WriteLine("{0} - {1}\nResources:", course.Name, course.Description);

            //    foreach (var resource in course.Resources)
            //    {
            //        Console.WriteLine("{0}, {1}, {2}", resource.Name, resource.ResourceType, resource.URL);
            //    }

            //    Console.WriteLine();
            //}

            //var courses = context.Courses
            //    .Where(c => c.Resources.Count() > 5)
            //    .OrderByDescending(c => c.Resources.Count)
            //    .ThenByDescending(c => c.StartDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        ResourceCount = c.Resources.Count
            //    }).ToList();

            //if (courses.Count == 0)
            //{
            //    Console.WriteLine("No course with more than five resources.");
            //}
            //else
            //{
            //    foreach (var course in courses)
            //    {
            //        Console.WriteLine("{0} has {1} resources.", course.Name, course.ResourceCount);
            //    }
            //}

            //var courses = context.Courses
            //    .Where(c => c.StartDate >= new DateTime(2015, 1, 28) && new DateTime(2015, 2, 14) <= c.EndDate)
            //    .OrderByDescending(c => c.Students.Count)
            //    .ThenByDescending(c => DbFunctions.DiffDays(c.EndDate, c.StartDate))
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.StartDate,
            //        c.EndDate,
            //        NumberOfStudents = c.Students.Count
            //    });

            //foreach (var course in courses)
            //{
            //    Console.WriteLine("{0} - {1}   {2}, {3}, {4}", course.Name, course.StartDate, course.EndDate,
            //        course.EndDate - course.StartDate, course.NumberOfStudents);
            //}

            var students = context.Students
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AveragePrice = s.Courses.Average(c => c.Price)
                });

            foreach (var student in students)
            {
                Console.WriteLine("{0} - {1}, {2}, {3}",student.Name, student.NumberOfCourses, student.TotalPrice, student.AveragePrice);
            }
        }

        public static void Seed(StudentContext context)
        {
            if (context.Students.Count() == 0 && context.Courses.Count() == 0 && context.Resources.Count() == 0 &&
                context.Homeworks.Count() == 0)
            {
                context.Students.Add(new Student()
                {
                    Name = "Haralmpi Zaprianski",
                    PhoneNumber = "+359 8822341569",
                    RegistrationDate = DateTime.Now,
                    Birthday = new DateTime(1996, 7, 22)
                });

                context.Students.Add(new Student()
                {
                    Name = "Icaka Marinov",
                    RegistrationDate = DateTime.Now,
                    Birthday = new DateTime(1999, 3, 3)
                });

                context.Students.Add(new Student()
                {
                    Name = "Valerian Peshterenski",
                    PhoneNumber = "+359 8882469485",
                    RegistrationDate = DateTime.Now,
                    Birthday = new DateTime(1985, 4, 12)
                });

                context.SaveChanges();

                var studentHaralampi = context.Students.Find(1);
                var studentIcaka = context.Students.Find(2);
                var studentValerian = context.Students.Find(3);
                var cSharpBasics = new Course()
                {
                    Name = "C# Basics",
                    Description = "Learn to code",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2015, 8, 2),
                    Price = 20m
                };
                var OOP = new Course()
                {
                    Name = "OOP",
                    Description = "Object-Oriented Programming Fundamentals",
                    StartDate = DateTime.Now,
                    EndDate = new DateTime(2015, 1, 18),
                    Price = 30m
                };
                var advancedJavaScript = new Course()
                {
                    Name = "Advanced JavaScript",
                    StartDate = new DateTime(2015, 1, 20),
                    EndDate = new DateTime(2015, 2, 15),
                    Price = 20m
                };

                studentHaralampi.Courses.Add(cSharpBasics);
                studentIcaka.Courses.Add(OOP);
                studentIcaka.Courses.Add(advancedJavaScript);
                studentValerian.Courses.Add(OOP);
                studentValerian.Courses.Add(advancedJavaScript);

                context.SaveChanges();

                var resourceVideoOne = new Resource()
                {
                    Name = "Videa",
                    ResourceType = ResourceType.Video,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 1
                };
                var resourcePresentationOne = new Resource()
                {
                    Name = "Prezentacii",
                    ResourceType = ResourceType.Presentation,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 1
                };
                var resourceVideoTwo = new Resource()
                {
                    Name = "Videa",
                    ResourceType = ResourceType.Video,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 2
                };
                var resourcePresentationTwo = new Resource()
                {
                    Name = "Prezentacii",
                    ResourceType = ResourceType.Presentation,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 2
                };
                var resourceVideoThree = new Resource()
                {
                    Name = "Videa",
                    ResourceType = ResourceType.Video,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 3
                };
                var resourcePresentationThree = new Resource()
                {
                    Name = "Prezentacii",
                    ResourceType = ResourceType.Presentation,
                    URL = "https://softuni.bg/trainings/1169/Database-Applications-Jul-2015",
                    CourseId = 3
                };

                var cSharpBasicsCourse = context.Courses.Find(1);
                var OOPCourse = context.Courses.Find(2);
                var advancedJavaScriptCourse = context.Courses.Find(3);

                cSharpBasicsCourse.Resources.Add(resourceVideoOne);
                cSharpBasicsCourse.Resources.Add(resourcePresentationOne);
                OOPCourse.Resources.Add(resourceVideoTwo);
                OOPCourse.Resources.Add(resourcePresentationTwo);
                advancedJavaScriptCourse.Resources.Add(resourceVideoThree);
                advancedJavaScriptCourse.Resources.Add(resourcePresentationThree);

                var homeworkOne = new Homework()
                {
                    Content = "Pisna mi",
                    ContentType = ContentType.ApplicationZip,
                    StudentId = 1,
                    CourseId = 1,
                    SubmissionDate = new DateTime(2015, 7, 23)
                };
                var homeworkTwo = new Homework()
                {
                    Content = "Pff",
                    ContentType = ContentType.ApplicationPDF,
                    StudentId = 2,
                    CourseId = 2,
                    SubmissionDate = new DateTime(2015, 6, 15)
                };
                var homeworkThree = new Homework()
                {
                    Content = "Offff",
                    ContentType = ContentType.ApplicationZip,
                    StudentId = 3,
                    CourseId = 3,
                    SubmissionDate = new DateTime(2015, 7, 21)
                };

                cSharpBasicsCourse.Homeworks.Add(homeworkOne);
                OOPCourse.Homeworks.Add(homeworkTwo);
                advancedJavaScriptCourse.Homeworks.Add(homeworkThree);

                context.SaveChanges();
            }
        }
    }
}
