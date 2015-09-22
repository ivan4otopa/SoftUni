using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentAndWorker
{
    class HumanStudentAndWorkerTest
    {
        static void Main()
        {
            Student studentOne = new Student("Mitko", "Mavrodiev", "asdsf");
            Student studentTwo = new Student("Filip", "Karlov", "12345");
            Student studentThree = new Student("Sezgin", "Petrov","aweqr");
            Student studentFour = new Student("Marta", "Karailianova", "19845");
            Student studentFive = new Student("Velichka", "Rambova", "16294");
            Student studentSix = new Student("Stavri", "Mavzuleev", "qwrqw");
            Student studentSeven = new Student("Silviq", "Djangova", "14243");
            Student studentEight = new Student("Roberto", "Haralambiev", "wqrat");
            Student studentNine = new Student("Hristomira", "Nikolaeva", "11455");
            Student studentTen = new Student("Zimbru", "Cesekaev", "grgfv");
            List<Student> students = new List<Student>();
            students.Add(studentOne);
            students.Add(studentTwo);
            students.Add(studentThree);
            students.Add(studentFour);
            students.Add(studentFive);
            students.Add(studentSix);
            students.Add(studentSeven);
            students.Add(studentEight);
            students.Add(studentNine);
            students.Add(studentTen);
            List<Student> sortedStudents = students.OrderBy(s => s.FacultyNumber).ToList();
            //foreach (var student in sortedStudents)
            //{
            //    Console.WriteLine(student);
            //}
            Worker workerOne = new Worker("Marto", "Grancharov", 50.35m, 6);
            Worker workerTwo = new Worker("Ianislav", "Marianov", 105.50m, 7);
            Worker workerThree = new Worker("Gonzo", "Levskarski", 10m, 11);
            Worker workerFour = new Worker("Bojana", "Georgieva", 300m, 3.30);
            Worker workerFive = new Worker("Petra", "Miniorska", 500m, 1.30);
            Worker workerSix = new Worker("Vaska", "Bojilova", 30.5m, 5);
            Worker workerSeven = new Worker("Hrizantema", "Jechkova", 330m, 4);
            Worker workerEight= new Worker("Vikoboi", "Karasemkov", 22m, 8.55);
            Worker workerNine = new Worker("Zevs", "Grumootvodov", 13m, 9.43);
            Worker workerTen = new Worker("Jivko", "Panteleimonov", 4m, 11.59);
            List<Worker> workers = new List<Worker>();
            workers.Add(workerOne);
            workers.Add(workerTwo);
            workers.Add(workerThree);
            workers.Add(workerFour);
            workers.Add(workerFive);
            workers.Add(workerSix);
            workers.Add(workerSeven);
            workers.Add(workerEight);
            workers.Add(workerNine);
            workers.Add(workerTen);
            List<Worker> sortedWorkers = workers.OrderByDescending(w => w.MoneyPerHour()).ToList();
            //foreach (var worker in sortedWorkers)
            //{
            //    //Console.WriteLine(worker.MoneyPerHour());
            //    Console.WriteLine(worker);
            //}
            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            List<Human> sortedHumans = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList();
            //foreach (var human in sortedHumans)
            //{
            //    Console.WriteLine(human);
            //}
        }
    }
}
